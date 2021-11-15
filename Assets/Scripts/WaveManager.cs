using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Singleton;
    public Text waveDisplay;
    public int wave = 1;
    public int maxWave = 3;

    [System.Serializable]
    public class IntEvent : UnityEvent<int>{}
    public IntEvent OnWaveStartEvent;

    public AudioSource audioSource;
    public AudioClip waveCompleteSound;
    public AudioClip gameWinSound;

    public static void setWaveStart(int w)
    {
        Singleton.OnWaveStartEvent.Invoke(w);
        updateText();
    }

    public static int getWave()
    {
        return Singleton.wave;
    }

    public static void nextWaveStart()
    {
        Singleton.wave += 1;
        if (Singleton.wave > Singleton.maxWave)
        {
            GameManager.setGameWin();
            Singleton.audioSource.PlayOneShot(Singleton.gameWinSound);
        }
        else
        {
            WaveManager.setWaveStart(Singleton.wave);
            updateText();
            Singleton.audioSource.PlayOneShot(Singleton.waveCompleteSound);
        }

    }

    public static void updateText()
    {
        Singleton.waveDisplay.text = String.Format("Wave: {0}", Singleton.wave);
    }

    void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        Singleton.audioSource = GetComponent<AudioSource>();
    }

    public static void waveReset()
    {
        Singleton.wave = 1;
        setWaveStart(1);
        updateText();
    }

    void Update()
    {
        if (EnemiesLeftManager.getEnemiesLeft() == 0)
        {
            nextWaveStart();
            updateText();
        }
    }
}

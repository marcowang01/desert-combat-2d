using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemiesLeftManager : MonoBehaviour
{
    public static EnemiesLeftManager Singleton;
    public Text EnemiesLeftDisplay;
    public int enemiesLeft = 10;

    public int wave1Enemies = 3;
    public int wave2Enemies = 15;
    public int wave3Enemies = 36;

    public UnityEvent OnNoEnemiesEvent;

    public static void setNewWave(int wave)
    {
        if (wave == 1)
            wave = Singleton.wave1Enemies;
        else if (wave == 2)
            wave = Singleton.wave2Enemies;
        else if (wave == 3)
            wave = Singleton.wave3Enemies;
        Singleton.enemiesLeft = wave;
        updateText();
    }

    public static void updateEnemiesLeft(int enemies)
    {
        Singleton.enemiesLeft -= enemies;
        updateText();
    }

    public static int getEnemiesLeft()
    {
        return Singleton.enemiesLeft;
    }

    public static void onNoEnemies()
    {
        Singleton.OnNoEnemiesEvent.Invoke();
    }

    public static void updateText()
    {
        Singleton.EnemiesLeftDisplay.text = String.Format("Enemies left: {0}", Singleton.enemiesLeft);
    }

    void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        updateText();
    }

    void Update()
    {
        if (enemiesLeft <= 0)
        {
            enemiesLeft = 0;
            onNoEnemies();
            updateText();
        }
    }
}

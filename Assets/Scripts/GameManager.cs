using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public Text gameOverDisplay;
    public bool gameOver;

    public AudioSource audioSource;
    public AudioClip gameStartSound;
    public AudioClip gameEndSound;

    //public UnityEvent OnGameOverEvent;
    public UnityEvent OnGameStartEvent;

    public static void setGameOver()
    {
        Singleton.gameOverDisplay.enabled = true;
        Singleton.gameOverDisplay.text = "GAME OVER";
        if (!Singleton.gameOver)
            Singleton.audioSource.PlayOneShot(Singleton.gameEndSound);
        Singleton.gameOver = true;
    }

    public static void setGameWin()
    {
        Singleton.gameOverDisplay.enabled = true;
        Singleton.gameOverDisplay.text = "YOU WIN";
        Singleton.gameOver = true;
    }

    public static void setGameStart()
    {
        Singleton.gameOverDisplay.enabled = false;
        Singleton.gameOver = false;
        ScoreManager.setScore(0);
        Singleton.OnGameStartEvent.Invoke();
        Singleton.audioSource.PlayOneShot(Singleton.gameStartSound);
    }

    public static bool isGameOver()
    {
        return Singleton.gameOver;
    }

    void Start()
    {
        Singleton = this;
        setGameStart();
    }

    void Update()
    {
        if (isGameOver() && Input.GetKeyUp("r"))
        {
            setGameStart();
        }
    }
}

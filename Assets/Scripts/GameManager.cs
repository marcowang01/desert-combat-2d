using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public Text gameOverDisplay;
    public bool gameOver;

    //public UnityEvent OnGameOverEvent;
    public UnityEvent OnGameStartEvent;

    public static void setGameOver()
    {
        Singleton.gameOverDisplay.enabled = true;
        Singleton.gameOver = true;
    }

    public static void setGameStart()
    {
        Singleton.gameOverDisplay.enabled = false;
        Singleton.gameOver = false;
        ScoreManager.setScore(0);
        Singleton.OnGameStartEvent.Invoke();
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

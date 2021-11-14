using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;  // everyone has the same score
    public static Text scoreText; // everyone has the same text


    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();
    }

    public static void updateScore(int points)
    {
        score += points;
        UpdateText();
    }

    public static void setScore(int points)
    {
        score = points;
        UpdateText();
    }

    public static int getScore()
    {
        return score;
    }

    private static void UpdateText()
    {
        if (scoreText)
        {
            scoreText.text = String.Format("Score: {0}", score);
        }
    }
}

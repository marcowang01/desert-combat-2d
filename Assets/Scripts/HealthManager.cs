using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private static int health;  // everyone has the same score
    private static Text healthText; // everyone has the same text
    public static HealthManager Singleton;

    // Use this for initialization
    internal void Start()
    {
        Singleton = this;
        healthText = GetComponent<Text>();
        UpdateText();
    }

    public static void updateHealth(int hp)
    {
        health = hp;
        UpdateText();
    }

    private static void UpdateText()
    {
        healthText.text = String.Format("HP: {0}", health);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private static int health;  // everyone has the same score
    private static Text healthText; // everyone has the same text


    // Use this for initialization
    internal void Start()
    {
        healthText = GetComponent<Text>();
        UpdateText();
    }

    public static void updateHealth(int hp)
    {
        health += hp;
        UpdateText();
    }

    public static void setHealth(int hp)
    {
        health = hp;
        UpdateText();
    }

    private static void UpdateText()
    {
        if (healthText)
        {
            healthText.text = String.Format("HP: {0}", health);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;
    public LayerMask playerLayer;
    public AudioSource audioSource;
    public AudioClip collectHealth;
    public int healthBoost = 3;

    public bool collected = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        animator.enabled = false;
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveManager.getWave() == 3 && !collected)
        {
            animator.enabled = true;
            sr.enabled = true;
            Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, 0.24f, playerLayer);
            foreach (Collider2D p in player)
            {
                PlayerDamage pd = p.GetComponent<PlayerDamage>();
                if (pd)
                {
                    pd.hitPoints += healthBoost;
                    collected = true;
                    animator.enabled = false;
                    sr.enabled = false;
                    audioSource.PlayOneShot(collectHealth);
                }
            }
        }
        if (WaveManager.getWave() != 3)
        {
            collected = false;
        }
    }
}

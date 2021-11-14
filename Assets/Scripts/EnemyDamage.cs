using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;

    public int pointsPerHp = 1;
    public int pointsPerDeath = 5;

    public int maxHitPoints = 3;
    public int hitPoints = 3;

    //public UnityEvent onDeathEvent;

    private bool isDying = false;

    // Update is called once per frame
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDamaged", false);
    }

    private void Update()
    {
        if (hitPoints == 0 && !isDying)
        {
            animator.SetTrigger("isDead");
            controller.isAlive = false;
            gameObject.GetComponent<EnemyMovement>().speed = 0;
        }
        if (GameManager.isGameOver())
        {
            die();
        }
    }

    public void takeDamage()
    {
        if (hitPoints > 0) 
        {
            ScoreManager.updateScore(pointsPerHp);
            hitPoints -= 1;
            animator.SetBool("isDamaged", true);
            controller.isAttacked = true;
            controller.isAttacking = false;
        }
    }

    public void die()
    {
        ScoreManager.updateScore(pointsPerDeath);
        Destroy(gameObject);
    }
}

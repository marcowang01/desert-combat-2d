using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;

    public int maxHP = 3;
    public int hitPoints = 3;
    public Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        HealthManager.updateHealth(hitPoints);
    }


    void Update()
    {
        if (hitPoints == 0)
        {
            die();
        }
    }

    public void takeDamage()
    {
        if (hitPoints > 0)
        {
            hitPoints -= 1;
            HealthManager.setHealth(hitPoints);
            controller.isAttacked = true;
            animator.SetTrigger("isDamaged");
        }
    }

    public void resetPlayer()
    {
        hitPoints = maxHP;
        HealthManager.setHealth(hitPoints);
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPos;
        gameObject.GetComponent<RobotController>().isAttacked = false;
    }

    private void die()
    {
        animator.SetTrigger("isDead");
        GameManager.setGameOver();
    }

    public void deactivate()
    {
        gameObject.SetActive(false);
    }

    
}

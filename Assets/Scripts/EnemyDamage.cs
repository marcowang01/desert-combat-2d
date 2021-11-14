using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;

    public int hitPoints = 3;

    // Update is called once per frame
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDamaged", false);
    }

    private void Update()
    {
        if (hitPoints == 0)
        {
            animator.SetTrigger("isDead");
        }
    }

    public void takeDamage()
    {
        if (hitPoints > 0) 
        {
            hitPoints -= 1;
            animator.SetBool("isDamaged", true);
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}

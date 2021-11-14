using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;
    

    public int hitPoints = 3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        HealthManager.updateHealth(hitPoints);
    }


    void Update()
    {
        
    }

    public void takeDamage()
    {
        hitPoints -= 1;
        HealthManager.updateHealth(hitPoints);
        animator.SetBool("isDamaged", true);
    }
}

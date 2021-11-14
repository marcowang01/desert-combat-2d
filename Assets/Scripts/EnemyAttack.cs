using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDamaged", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        animator.SetBool("isDamaged", true);
    }


}

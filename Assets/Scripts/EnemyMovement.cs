using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public RobotController controller;
    public Animator animator;
    public LayerMask enemiesLayer;
    public Transform enemyTransform;

    public float speed = 10f;
    float xDisplacement = 0f;

    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        xDisplacement = -10;
        enemyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", xDisplacement * xDisplacement);
        if ((enemyTransform.position.x < -9 && xDisplacement < 0) 
            || (enemyTransform.position.x > 9 && xDisplacement > 0))
        {
            xDisplacement = -xDisplacement;
        }
    }


    private void FixedUpdate()
    {
        if (controller.isAttacking && !controller.isAlive)
        {
            controller.Move(0);
        } else
        {
            controller.Move(xDisplacement * speed * Time.fixedDeltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public RobotController controller;
    public Animator animator;
    public LayerMask enemiesLayer;
    public Transform enemyTransform;
    public float initSpeed = 2f;
    public float speed = 2f;
    public float initXDisplacement = 10f;
    public float xDisplacement = 0f;

    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        initSpeed = Random.Range(1.0f, 1.5f);
        speed = initSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDamage player = FindObjectOfType<PlayerDamage>();
        if (player.gameObject.transform.position.x < transform.position.x && xDisplacement > 0)
        {
            xDisplacement = -xDisplacement;
        } else if (player.gameObject.transform.position.x > transform.position.x && xDisplacement < 0)
        {
            xDisplacement = -xDisplacement;
        }

        float dist = player.gameObject.transform.position.x - transform.position.x;
        if (Mathf.Abs(dist) < 1.5)
            speed = 0;
        else
            speed = initSpeed;

        animator.SetFloat("speed", Mathf.Abs(xDisplacement) * speed);
        if ((enemyTransform.position.x < -9 && xDisplacement < 0) 
            || (enemyTransform.position.x > 9 && xDisplacement > 0))
        {
            xDisplacement = -xDisplacement;
        }
    }


    private void FixedUpdate()
    {
        if (controller.isAttacking || GetComponent<EnemyDamage>().hitPoints == 0)
        {
            controller.Move(0);
        } else
        {
            controller.Move(xDisplacement * speed * Time.fixedDeltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public RobotController controller;
    public Animator animator;

    public Transform attackPoint;
    public float attackRadius = 12f;
    public LayerMask enemyLayer;

    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            animator.SetTrigger("isAttacking");
            Attack();
        }
    }

    public void Attack()
    {
        // Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        Vector2 size = new Vector2(attackRadius * 2, attackRadius / 2);
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(
            attackPoint.position, size, CapsuleDirection2D.Horizontal, 0, enemyLayer);
        foreach (Collider2D e in enemies)
        {
            e.GetComponent<EnemyAttack>().takeDamage();
        }
    }

    public void takeDamage()
    {
        animator.SetBool("isDamaged", true);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}

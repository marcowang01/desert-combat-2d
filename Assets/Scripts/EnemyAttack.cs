using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public RobotController controller;
    public Animator animator;

    public float coolDown = 2f;
    public float coolDownCount = 0;

    public Transform attackPoint;
    public Transform attackPoint2;
    public float attackRadius = 12f;
    public float attackRadius2 = 12f;
    public LayerMask playerLayer;

    public AudioSource audioSource;
    public AudioClip hitMeeleSound;
    public AudioClip hitRangeSound;

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
        if (Time.time > coolDownCount)
        {
            if (WaveManager.getWave() == 2)
            {
                if (Random.Range(0.0f, 1.0f) > 0.5)
                {
                    animator.SetTrigger("isRangeAttacking");
                }
                else
                {
                    animator.SetTrigger("isAttacking");
                }
            }
            else if (WaveManager.getWave() == 3)
            {
                if (Random.Range(0.0f, 1.0f) > 0.2)
                {
                    animator.SetTrigger("isRangeAttacking");
                }
                else
                {
                    animator.SetTrigger("isAttacking");
                }
            } else
            {
                animator.SetTrigger("isAttacking");
            }
            controller.isAttacking = true;
            coolDownCount = Time.time + coolDown;
        }
    }

    public void Attack()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
        foreach (Collider2D p in player)
        {
            PlayerDamage pd = p.GetComponent<PlayerDamage>();
            if (pd)
            {
                pd.takeDamage();
                audioSource.PlayOneShot(hitMeeleSound);
            }
        }
    }

    public void AttackRange()
    {
        
        Vector2 size = new Vector2(attackRadius2 * 2, attackRadius2 / 4);
        Collider2D[] player = Physics2D.OverlapCapsuleAll(
            attackPoint2.position, size, CapsuleDirection2D.Horizontal, 0, playerLayer);
        foreach (Collider2D p in player)
        {
            PlayerDamage pd = p.GetComponent<PlayerDamage>();
            if (pd)
            {
                pd.takeDamage();
                audioSource.PlayOneShot(hitRangeSound);
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        if (attackPoint2 == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint2.position, attackRadius2);
    }


}

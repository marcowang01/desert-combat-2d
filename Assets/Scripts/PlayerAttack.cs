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

    public float attackCD = 0.5f;
    public float attackCDCount = 0;

    private float holdTime = 0;
    public bool isCharging = false;

    public AudioSource audioSource;
    public AudioClip attackSound;
    public AudioClip hitSound;
    public AudioClip chargeSound;

    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j") && Time.time > attackCDCount)
        {
            animator.SetTrigger("isAttacking");
            Attack();
            attackCDCount = Time.time + attackCD;
        } else if (Input.GetKeyDown("k"))
        {
            isCharging = true;
            Charge();
        } else if (Input.GetKeyUp("k"))
        {
            isCharging = false;
            animator.SetFloat("holdTime", Time.time - holdTime);
            holdTime = 0;
            animator.SetBool("isCharging", false);
            if (holdTime > attackCD)
            {
                Attack();
            }
        }
        if (isCharging)
        {
            audioSource.PlayOneShot(chargeSound, 0.3f);

        }
    }

    public void Attack()
    {
        bool hit = false;
        
        Vector2 size = new Vector2(attackRadius * 2, attackRadius / 2);
        Collider2D[] enemies = Physics2D.OverlapCapsuleAll(
            attackPoint.position, size, CapsuleDirection2D.Horizontal, 0, enemyLayer);
        foreach (Collider2D e in enemies)
        {
            EnemyDamage ed = e.GetComponent<EnemyDamage>();
            if (ed)
            {
                ed.takeDamage();
                hit = true;
            }
            
        }
        if (!hit)
        {
            audioSource.PlayOneShot(attackSound);
        } else
        {
            audioSource.PlayOneShot(hitSound, 0.7f);
        }
    }

    public void Charge()
    {
        animator.SetBool("isCharging",  true);
        holdTime = Time.time;
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

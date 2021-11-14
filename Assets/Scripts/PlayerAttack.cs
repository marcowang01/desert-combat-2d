using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            animator.SetBool("isAttacking", true);
        }
    }

    public void OnAttackAnimDone()
    {
        animator.SetBool("isAttacking", false);
    }
}

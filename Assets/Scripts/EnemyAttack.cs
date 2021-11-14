using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
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
        if (Input.GetKeyDown("d"))
        {
            animator.SetBool("isDamaged", true);
        }
    }

    public void OnDamageAnimDone()
    {
        animator.SetBool("isDamaged", false);
    }
}

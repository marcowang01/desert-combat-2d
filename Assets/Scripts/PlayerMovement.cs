using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public RobotController controller;
    public Animator animator;

    public float speed = 1f;
    float xDisplacement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<RobotController>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        xDisplacement = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("speed", xDisplacement * xDisplacement); 
    }

    private void FixedUpdate()
    {
        controller.Move(xDisplacement * Time.fixedDeltaTime);
    }

}

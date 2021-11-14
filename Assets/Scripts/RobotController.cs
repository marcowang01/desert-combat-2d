using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RobotController : MonoBehaviour
{   
	// variables for movement
	private bool isFacingRight = true;
	[SerializeField] private float smoothingTime = .05f;
	private Vector3 inputVelocity = Vector3.zero;

	// variables for attack/damage
	private bool isAttacked;

	// events for attack
	public UnityEvent OnDamageEvent;
	public UnityEvent PlayerAttack2Event;

	private Rigidbody2D rb;

	private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;

		if (OnDamageEvent == null)
			OnDamageEvent = new UnityEvent();
	}

    private void FixedUpdate()
    {
        
    }

	public void Move(float v)
	{
		//only control the player if grounded or airControl is turned on
		if (!isAttacked )
		{
			Vector3 targetVelocity = new Vector2(v * 10f, 0);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref inputVelocity, smoothingTime);

			if (v > 0 && !isFacingRight)
			{
				Flip();
			}

			else if (v < 0 && isFacingRight)
			{
				Flip();
			}
		}
	}


	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void onPlayerAttack2()
    {
		PlayerAttack2Event.Invoke();
    }

}

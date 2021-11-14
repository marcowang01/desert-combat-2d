using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{   
	// variables for movement
	private bool isFacingRight = true;
	[SerializeField] private float smoothingTime = .05f;
	private Vector3 inputVelocity = Vector3.zero;

	// variables for attack/damage
	const float attackedRadius = .2f;
	private bool isAttacked;

	// events for attack
	public UnityEvent OnAttackAnimDoneEvent;
	public UnityEvent OnDamageAnimDoneEvent;

	private Rigidbody2D rb;

	private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 0;


		if (OnAttackAnimDoneEvent == null)
			OnAttackAnimDoneEvent = new UnityEvent();

		if (OnDamageAnimDoneEvent == null)
			OnDamageAnimDoneEvent = new UnityEvent();
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

	private void attackDone()
    {
		OnAttackAnimDoneEvent.Invoke();
    }

	private void damageDone()
	{
		OnDamageAnimDoneEvent.Invoke();
	}

}

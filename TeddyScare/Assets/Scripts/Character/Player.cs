using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Collider2D hitCollider;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundradius;
	[SerializeField]
	private LayerMask ground;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private bool airControl;

	public Rigidbody2D PlayerBody { get; set; }
	public bool Jump { get; set; }
	public bool OnGround { get; set; }

	// Use this for initialization
	public override void Start()
	{
		base.Start();
		PlayerBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//If we fall off the map position us at the start again
		if (transform.position.y <= -14f)
		{
			PlayerBody.velocity = Vector2.zero;
			transform.position = StartPos;
		}

		HandleInput();
	}


	void FixedUpdate()
	{
		OnGround = IsGrounded();
		Move();
		Flip();
		HandleLayers();
	}

	void HandleInput()
	{
		if (Input.GetButton("Claw"))
		{
			Anim.SetTrigger("Attack");
		}
		if (Input.GetButton("Jump"))
		{
			Anim.SetTrigger("Jump");
		}
		if (Input.GetButtonDown("Roar"))
		{
			Anim.SetTrigger("Roar");
		}
	}

	void Move()
	{
		float horizontal = Input.GetAxis("Horizontal");
		Anim.SetFloat("Speed", Mathf.Abs(horizontal));
		if (PlayerBody.velocity.y < 0)
		{
			Anim.SetBool("Land", true);
		}
		if (!Attack && (OnGround || airControl))
		{
			PlayerBody.velocity = new Vector2(horizontal * movementSpeed, PlayerBody.velocity.y);
		}
		if (Jump && PlayerBody.velocity.y == 0)
		{
			PlayerBody.AddForce(new Vector2(0, jumpForce));
		}

		Anim.SetFloat("Speed", Mathf.Abs(horizontal));
	}
	void Flip()
	{
		float horizontal = Input.GetAxis("Horizontal");
		if (horizontal > 0 && !facingRight || facingRight && horizontal < 0)
		{
			ChangeDirection();
		}
	}

	bool IsGrounded()
	{
		if (PlayerBody.velocity.y <= 0)
		{
			foreach (Transform p in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(p.position, groundradius, ground);

				foreach (Collider2D c in colliders)
				{
					if (c.gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}
	void HandleLayers()
	{
		if (!OnGround)
		{
			Anim.SetLayerWeight(1, 1);
		}
		else
		{
			Anim.SetLayerWeight(1, 0);
		}
	}

    public void MeleeAttack()
    {
        hitCollider.enabled = !hitCollider.enabled;
        
    }
    

	protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Level")
		{
			Game.Instance.NextLevel();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : Enemy
{
	private bool run = false;
	public override void Start()
	{
		base.Start();
		facingRight = false;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
        if (!dead)
        {
            if (LineOfSightToPlayer())
            {
                //Run away
                Level.Instance.AddToDangerLevel();
                Anim.SetFloat("Speed", 1f);
                run = true;
                ChangeDirection();
                Move();
            }
            if (run)
            {
                Move();
            }
        }
	}

	public override void Reset()
	{
		base.Reset();
        Anim.SetFloat("Speed", 0f);
        run = false;
        if (facingRight)
        {
            ChangeDirection();
        }
    }

    protected override void die()
    {
        Anim.SetTrigger("Dead");
        Level.Instance.AddToDangerLevel(3);
    }
}

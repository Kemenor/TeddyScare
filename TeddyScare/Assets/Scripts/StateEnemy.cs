using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateEnemy : Enemy
{
	[SerializeField]
	protected IEnemyState currentState;
	// Use this for initialization
	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (currentState != null)
		{
			currentState.Execute();
		}
	}

	protected void OnTriggerEnter2D(Collider2D collision)
	{
		currentState.OnTriggerenter(collision);
	}

	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null)
		{
			currentState.Exit();
		}

		currentState = newState;
		currentState.Enter(this);
	}
}

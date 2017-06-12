using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarBackToStartState : IEnemyState
{
	private StateEnemy enemy;

	public void Enter(StateEnemy enemy)
	{
		this.enemy = enemy;
		enemy.Anim.SetFloat("Speed", 1.0f);
	}

	public void Execute()
	{
		if (enemy.LineOfSightToPlayer() || enemy.OverlapsPlayer())
		{
			enemy.ChangeState(new BoarFollowState());
		}
		Vector2 dir = ((Vector2)enemy.transform.position - enemy.StartPos).normalized;
		if (dir == enemy.GetDirection())
		{
			enemy.ChangeDirection();
		}
		enemy.Move();
		if (Math.Abs(enemy.transform.position.x - enemy.StartPos.x) < 0.5f)
		{
			enemy.ChangeState(new BoarIdleState());
		}
	}

	public void Exit()
	{
	}

	public void OnTriggerenter(Collider2D other)
	{
	}
}

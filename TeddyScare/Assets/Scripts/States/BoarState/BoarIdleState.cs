using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarIdleState : IEnemyState
{

	private StateEnemy enemy;

	private float idleTimer = 0;
	private float idleDuration = 5f;
	public void Enter(StateEnemy enemy)
	{
		enemy.Anim.SetFloat("Speed", 0f);
		this.enemy = enemy;
	}

	public void Execute()
	{

		if (enemy.LineOfSightToPlayer() || enemy.OverlapsPlayer())
		{
			enemy.ChangeState(new BoarFollowState());
		}
		idleTimer += Time.deltaTime;
		if (idleTimer >= idleDuration)
		{
			idleTimer = 0;
			enemy.ChangeState(new BoarPatrolState());
		}
	}

	public void Exit()
	{
	}

	public void OnTriggerenter(Collider2D other)
	{
	}
}

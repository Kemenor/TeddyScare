using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarPatrolState : IEnemyState
{
    private StateEnemy enemy;
    private float patrolTimer;
    private float patrolDuration = 15f;

    public void Enter(StateEnemy enemy)
    {
        this.enemy = enemy;
        enemy.Anim.SetFloat("Speed", 1f);
    }

    public void Execute()
    {
        if (enemy.LineOfSightToPlayer())
        {
            enemy.ChangeState(new BoarFollowState());
        }
        if (enemy.OverlapsPlayer())
        {
            enemy.ChangeState(new BoarFollowState());
        }
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new BoarIdleState());
        }
        enemy.Move();
    }

    public void Exit()
    {
    }

    public void OnTriggerenter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            enemy.ChangeDirection();
        }
        if (other.tag == "idle")
        {
            enemy.ChangeState(new BoarIdleState());
        }
    }

}

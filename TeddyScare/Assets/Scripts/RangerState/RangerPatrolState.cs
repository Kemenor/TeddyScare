using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerPatrolState : IEnemyState
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
            enemy.ChangeState(new RangerAttackState());
        }
        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new RangerIdleState());
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
        if(other.tag == "idle")
        {
            enemy.ChangeState(new RangerIdleState());
        }
    }
}

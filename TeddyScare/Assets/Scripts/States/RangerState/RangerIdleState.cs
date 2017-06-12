using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerIdleState : IEnemyState
{
    private StateEnemy enemy;

    private float idleTimer = 0;
    private float idleDuration = 5f;
    private bool turn = false;

    public RangerIdleState()
    {

    }

    public RangerIdleState(bool turnaround)
    {
        this.turn = turnaround;
    }
    public void Enter(StateEnemy enemy)
    {
        enemy.Anim.SetFloat("Speed", 0f);
        this.enemy = enemy;
    }

    public void Execute()
    {

        if (enemy.LineOfSightToPlayer())
        {
            enemy.ChangeState(new RangerAttackState());
        }
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            idleTimer = 0;
            enemy.ChangeState(new RangerPatrolState());
            if (turn)
            {
                enemy.ChangeDirection();
            }
        }
    }

    public void Exit()
    {
       
    }

    public void OnTriggerenter(Collider2D other)
    {
    }
}

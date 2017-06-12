using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarFollowState : IEnemyState {
    private StateEnemy enemy;
    private float followTimer = 0;
    private float followDuration = 1f;
    public void Enter(StateEnemy enemy)
    {
        this.enemy = enemy;
        this.enemy.Anim.SetFloat("Speed", 2.0f);
    }

    public void Execute()
    {
        if (enemy.OverlapsPlayer())
        {
            enemy.ChangeState(new BoarAttackState());
        }
        if (enemy.LineOfSightToPlayer())
        {
            this.enemy.Anim.SetFloat("Speed", 2.0f);
            Collider2D target = Level.Player.GetComponent<Collider2D>();
            Vector2 direction = enemy.GetDirection(target);
            if (direction == enemy.GetDirection())
            {
                enemy.ChangeDirection();
            }
            enemy.Run();
        }
        else
        {
            this.enemy.Anim.SetFloat("Speed", 0f);
            followTimer += Time.deltaTime;
            if (followTimer >= followDuration)
            {
                followTimer = 0;
                enemy.ChangeState(new BoarBackToStartState());
            }
        }
    }

    public void Exit()
    {
    }

    public void OnTriggerenter(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy.ChangeState(new BoarBackToStartState());
        }
    }
}

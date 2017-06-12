using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPatrolState : IEnemyState
{
    private StateEnemy enemy;
    public void Enter(StateEnemy enemy)
    {
        this.enemy = enemy;
        enemy.Anim.SetFloat("Speed", 1f);
    }

    public void Execute()
    {
        enemy.Move();
    }

    public void Exit()
    {
    }

    public void OnTriggerenter(Collider2D other)
    {
        if (other.tag == "Edge")
        {
            enemy.ChangeState(new WolfIdleState());
        }
    }

}

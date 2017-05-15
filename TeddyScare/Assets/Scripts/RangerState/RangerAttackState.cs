using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttackState : IEnemyState
{
    public void Enter(StateEnemy enemy)
    {
        enemy.Anim.SetFloat("Speed", 0f);
        enemy.Anim.SetTrigger("Attack");
    }

    public void Execute()
    {
    }

    public void Exit()
    {
    }

    public void OnTriggerenter(Collider2D other)
    {
    }
}

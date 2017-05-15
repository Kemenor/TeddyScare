using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IEnemyState
{
    public void Enter(StateEnemy enemy)
    {
        enemy.Anim.SetFloat("Speed", 0);
        enemy.Anim.SetTrigger("Death");
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

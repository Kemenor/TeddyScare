using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : StateEnemy {
    public override void Start()
    {
        base.Start();
        ChangeState(new BoarPatrolState());
    }

    public override void Reset()
    {
        base.Reset();
        ChangeState(new BoarIdleState());
    }
    
    public void HitPlayer()
    {
        Debug.Log("Hitting Player");
        //Check if HitBox
        Collider2D boar = GetComponent<Collider2D>();
        if (boar.bounds.Intersects(Level.Player.GetComponent<Collider2D>().bounds))
        {
            Level.Instance.KillPlayer();
        }
        else
        {
            ChangeState(new BoarBackToStartState());
        }
    }
}

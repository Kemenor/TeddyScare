using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookout : StateEnemy
{
    public override void Start()
    {
        base.Start();
        ChangeState(new LookoutPatrolState());
    }

    public override void Reset()
    {
        base.Reset();
        ChangeState(new LookoutPatrolState());
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : StateEnemy
{
	public override void Start()
	{
		base.Start();
		ChangeState(new RangerIdleState());
	}
	public override void Reset()
	{
		base.Reset();
		ChangeState(new RangerIdleState());
	}


	public void ShootPlayer()
	{
		//Los check kill player
		if (LineOfSightToPlayer(2))
		{
			//kill player
			Level.Instance.KillPlayer();
		}
		else
		{
			ChangeState(new RangerPatrolState());
		}

	}
}
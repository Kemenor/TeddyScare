using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBehaviour : StateMachineBehaviour
{

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Player player = Level.Player;
		if (player.OnGround)
		{
			animator.SetBool("Land", false);
			animator.ResetTrigger("Jump");
		}
	}
}

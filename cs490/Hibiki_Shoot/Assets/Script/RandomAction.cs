using UnityEngine;
using System.Collections;


public class RandomAction : StateMachineBehaviour {


	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
//		Debug.Log("RandomAction : OnStateMachineEnter");
		float rotation = Random.Range (-30.0f, 30.0f);
		animator.SetInteger ("actionID", Random.Range(0, 3));
//		animator.SetInteger ("actionID", 0);
		if (animator.GetInteger ("actionID") == 0 || animator.GetInteger ("actionID") == 3)
			animator.transform.Rotate (0, rotation, 0);
	}

}
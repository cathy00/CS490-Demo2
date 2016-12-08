using UnityEngine;
using System.Collections;

public class WalkMotion : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("Before: " + animator.transform.position);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		if (animator.transform.position.z < -5) {
			animator.transform.Rotate (0, 0.8f, 0);
		}
		else if (animator.transform.position.x > 10) {
			animator.transform.Rotate (0, 0.8f, 0);
		}
		else if (animator.transform.position.z > 5) {
			animator.transform.Rotate (0, 0.8f, 0);
		}
		else if (animator.transform.position.x < -10) {
			animator.transform.Rotate (0, 0.8f, 0);
		}
		animator.transform.Translate (Vector3.forward * Time.deltaTime * 2);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("After: " + animator.transform.position);
	}

}

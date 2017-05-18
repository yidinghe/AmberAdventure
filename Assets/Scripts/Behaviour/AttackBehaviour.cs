using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {

	public float transhold = 1;
	public int order = 0;

	void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		if (animatorStateInfo.normalizedTime <= transhold) {
			animator.SetInteger ("Attack", order);
		}

	}

	void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		animator.SetInteger("Attack", 0) ;
	}
}

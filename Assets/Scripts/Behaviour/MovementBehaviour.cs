using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : StateMachineBehaviour {

	void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		animator.ResetTrigger ("Skill");
	}
}

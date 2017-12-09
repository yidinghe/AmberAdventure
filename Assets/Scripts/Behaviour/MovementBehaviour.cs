using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : StateMachineBehaviour {

	void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		//所有的动作状态都在movement的结束来清零.不需要在每个动画的结束来清零
		animator.ResetTrigger ("Skill");
		animator.GetComponentInParent<Controller>().lockMove = false ;
		animator.GetComponentInParent<Rigidbody2D> ().drag = 0;
	}

}

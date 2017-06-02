using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : StateMachineBehaviour {


	void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		//下落时候的空气阻力加大
		animator.GetComponentInParent<Rigidbody2D> ().drag = 15;
	}

	void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex){
		animator.GetComponentInParent<Rigidbody2D> ().drag = 0;
	}
		
}

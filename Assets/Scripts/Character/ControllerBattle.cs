using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBattle : Controller
{

	public override void Control ()
	{
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Z)) {
			Move (0);
			lockMove = true;
			anim.SetInteger ("Attack", anim.GetInteger ("Attack") + 1);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			Move (0);
			lockMove = true;
			anim.SetTrigger ("Skill");
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			Move (0);
			lockMove = true;
			anim.SetBool ("Shot", true);
		}

		if (Input.GetKeyUp (KeyCode.X)) {
			anim.SetBool ("Shot", false);
		}
	}

	public override void Move(int i){
//		if(lockMove){
//			body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
//		}	
		body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		anim.SetFloat ("Move", Mathf.Abs (i));
	}
		
	public override void Direction(int i){
//		if (lockMove)
//			return;
		transform.eulerAngles = new Vector3 (0, 180f * i, 0);
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBattle : Controller
{

	public override void Control ()
	{
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Z)) {
			body.velocity = new Vector2 (0, body.velocity.y);
			anim.SetInteger ("Attack", anim.GetInteger ("Attack") + 1);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			body.velocity = new Vector2 (0, body.velocity.y);
			anim.SetTrigger ("Skill");
		}
	}

	public override void Move(int i){
		if(CanMove()){
			body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		}	
	
		anim.SetFloat ("Move", Mathf.Abs (i));
	}
		
	public override void Direction(int i){
//		if (CanMove ())
//			return;
		transform.eulerAngles = new Vector3 (0, 180f * i, 0);
	}

	bool CanMove(){
		return !state.IsTag ("lock");
	}
}

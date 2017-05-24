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
	}

	public override void Move(int i){
		if(CanMove()){
			body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		}	
	
		anim.SetFloat ("Move", Mathf.Abs (i));
	}

//	public override void Direction(int i){
//	
//	}

	bool CanMove(){
		return !state.IsTag ("lock");
	}
}

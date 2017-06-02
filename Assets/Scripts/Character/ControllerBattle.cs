using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBattle : Controller
{
	internal bool isShotStart = false;

	public override void Control ()
	{
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Z)) {
			OnKeyADown ();
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			OnKeyBDown ();
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			isShotStart = true;
			body.velocity = new Vector2 (body.velocity.x, 0);
			Move (0);
			lockMove = true;
			anim.SetBool ("Shot", true);
		}

		if (Input.GetKeyUp (KeyCode.X)) {
			isShotStart = false;
			anim.SetBool ("Shot", false);
		}
	}

	public override void Move (int i)
	{
//		if(lockMove){
//			body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
//		}	
		body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		anim.SetFloat ("Move", Mathf.Abs (i));
	}

	public override void Direction (int i)
	{
//		if (lockMove)
//			return;
		transform.eulerAngles = new Vector3 (0, 180f * i, 0);
	}

	public void OnKeyADown ()
	{
		Move (0);
		lockMove = true;
		anim.SetInteger ("Attack", anim.GetInteger ("Attack") + 1);
	}

	public void OnKeyBDown ()
	{
		Move (0);
		lockMove = true;
		anim.SetTrigger ("Skill");
	}

	public void OnKeyXDown ()
	{
		if (isShotStart) {
			anim.SetBool ("Shot", false);	
		} else {
			Move (0);
			lockMove = true;
			anim.SetBool ("Shot", true);
		}

		isShotStart = !isShotStart;
	}
		
}

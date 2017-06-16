using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

	public float speed = 200f;
	public float jumpHeight = 15;
	internal bool isGround = false;
	internal Rigidbody2D body;
	internal Animator anim;
	internal bool isKeyLeftOrRightTouched = false;
	internal AnimatorStateInfo state;
	internal bool lockMove = false;
	internal bool isMoveRightStart = false;
	internal bool isMoveLeftStart = false;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
	}
		

	// Use this for initialization
	void Start ()
	{
		

	}
	// Update is called once per frame
	void Update ()
	{
		Control ();

		CheckMobileSupport ();

		StateMachine ();

	}

	private void CheckMobileSupport()
	{
		if (!Game.isTurnOnDebug) {
			if (isMoveRightStart) {
				OnKeyRight ();
			}

			if (isMoveLeftStart) {
				OnKeyLeft ();
			}

			if (!isMoveLeftStart && !isMoveRightStart) {
				StopMoving ();
			}
		}
	}

	void Jump ()
	{
		if (!isGround)
			return;
		isGround = false;
		body.velocity = new Vector2 (body.velocity.x, jumpHeight);
		anim.SetTrigger ("Jump");
	}

	public virtual void Move (int i)
	{
		body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		anim.SetFloat ("Move", Mathf.Abs (i));
	}

	public virtual void Direction (int i)
	{
		transform.eulerAngles = new Vector3 (0, 180f * i, 0);
	}

	public void StateMachine ()
	{
		anim.SetBool ("Ground", isGround);
		anim.SetFloat ("Y", body.velocity.y);
		state = anim.GetCurrentAnimatorStateInfo (0);
	}


	void OnCollisionStay2D (Collision2D col)
	{
		if (col.contacts[0].normal != Vector2.up)
			return;

		if (col.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			isGround = true;
		}
	}


	void OnCollisionExit2D (Collision2D col)
	{
		if (col.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			isGround = false;
		}
	}
		
	public virtual void  Control(){
		bool upKey = Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow);

		if (Input.GetKey (KeyCode.RightArrow)) {
			Move (1);
			Direction (0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Move (-1);
			Direction (1);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

		if (upKey) {
			StopMoving ();
		}
	}
		

	private bool IsTouchEnded ()
	{
		return Input.GetMouseButtonUp (0) || (Input.touchSupported && (Input.GetTouch (0).phase == TouchPhase.Ended));
	}

	private void StopMoving(){
		Move (0); 
	}

	public void OnKeyRightDown ()
	{
		if (isMoveRightStart || isMoveLeftStart) {
			isMoveRightStart = false;
			isMoveLeftStart = false;
		} else {
			isMoveRightStart = true;
			isMoveLeftStart = false;
		}

	}

	public void OnKeyLeftDown ()
	{
		if (isMoveRightStart || isMoveLeftStart) {
			isMoveRightStart = false;
			isMoveLeftStart = false;
		} else {
			isMoveLeftStart = true;
			isMoveRightStart = false;
		}

	}

	public void OnKeyRight ()
	{
		Move (1);
		Direction (0);
	}


	public void OnKeyLeft ()
	{
		Move (-1);
		Direction (1);
	}


	public void OnKeyUp ()
	{
		Jump ();
	}

}

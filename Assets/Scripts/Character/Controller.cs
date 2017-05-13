using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

	public float speed = 200f;
	public float jumpHeight = 9;
	internal bool isGround = false;
	internal Rigidbody2D body;
	internal Animator anim;

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
			Move (0);
		}



		CheckMobileSupport ();

		StateMachine ();

	}

	void Jump ()
	{
		if (!isGround)
			return;
		isGround = false;
		body.velocity = new Vector2 (body.velocity.x, jumpHeight);
		anim.SetTrigger ("Jump");
	}

	void Move (int i)
	{
		body.velocity = new Vector2 (i * speed * Time.deltaTime, body.velocity.y);
		anim.SetFloat ("Move", Mathf.Abs (i));
	}

	void Direction (int i)
	{
		transform.eulerAngles = new Vector3 (0, 180f * i, 0);
	}

	public void StateMachine(){
		anim.SetBool ("Ground", isGround);
		anim.SetFloat ("Y", body.velocity.y);
	}

	void OnCollisionStay2D (Collision2D col)
	{
		isGround = true;
	}

	void OnCollisionExit2D (Collision2D col)
	{
		isGround = false;
	}


	private void CheckMobileSupport ()
	{
		if (!Game.isTurnOnDebug && !Input.touchSupported) {
			return;
		}
			
		if (Input.touchSupported && Input.GetTouch (0).phase == TouchPhase.Ended) {
			//handle the touch up, (Input.GetTouch (0).phase == TouchPhase.Ended) is much more reliable
			Move (0);
			return;
		}
	
		// TODO work on the layers

		Collider2D[] col = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint (Input.mousePosition));

		if (col.Length > 0) {
			foreach (Collider2D c in col) {

				if (c.name == "arrowRight") {
					OnKeyRight ();
				} else if (c.name == "arrowLeft") {
					OnKeyLeft ();
				} else if (c.name == "arrowUp" && Input.touchSupported && Input.GetTouch (0).phase == TouchPhase.Began) {
					OnKeyUp ();
				} 
			}
		} else {
			Move (0);
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
		if (Input.GetButtonDown ("Fire1")) { 
			Jump ();
		}
	}

}

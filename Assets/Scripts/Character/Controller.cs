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
			return;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Move (-1);
			Direction (1);
			return;
		}

		if (Input.GetKey (KeyCode.Space)) {
			Jump ();
			return;
		}

		if (upKey) {
			Move (0);
			return;
		}

		CheckMobileSupport ();

	}

	void Jump ()
	{
		if (!isGround)
			return;
		body.velocity = new Vector2 (body.velocity.x, jumpHeight);
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

	void OnCollisionStay2D (Collision2D col)
	{
		Debug.Log ("onCollisionStay2D" + col.collider.name);
		isGround = true;
	}

	void OnCollisionExit2D (Collision2D col)
	{
		Debug.Log ("onCollistionExit2D" + col.collider.name);
		isGround = false;
	}


	private void CheckMobileSupport ()
	{
		Collider2D[] col = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint (Input.mousePosition));

		if (col.Length > 0) {
			foreach (Collider2D c in col) {
				if (c.name == "arrowRight") {
					OnKeyRight ();
				} else if (c.name == "arrowLeft") {
					OnKeyLeft ();
				} else if (c.name == "arrowUp") {
					OnKeyUp ();
				} else {
					Move (0);
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

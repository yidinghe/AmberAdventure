using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed = 200f;
	internal Rigidbody2D body;

	void Awake(){
		body = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool upKey = Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow);

		if (Input.GetKey (KeyCode.RightArrow)) {
			Move (1);
			Direction(0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Move (-1);
			Direction(1);
		}

		if (upKey) {
			Move (0);
		}

	}

	void Move(int i){
		body.velocity = new Vector2(i*speed*Time.deltaTime, body.velocity.y) ;
	}

	void Direction(int i){
		transform.eulerAngles = new Vector3 (0, 180f*i, 0);
	}
}

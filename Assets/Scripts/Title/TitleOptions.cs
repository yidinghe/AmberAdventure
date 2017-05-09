using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOptions : MonoBehaviour
{

	public Transform hand;
	public Transform[] buttons;
	public float[] xOffset;
	public World world;
	public AudioClip moveSound;
	public AudioClip okSound;
	int id = 0;

	// Use this for initialization
	void Start ()
	{
		world = FindObjectOfType<World> ();
		id = 1;
		UpdatePosition ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			id--;
			id = Mathf.Clamp (id, 0, 2);
			world.sound.PlaySE (moveSound);
			UpdatePosition ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			id++;
			id = Mathf.Clamp (id, 0, 2);
			world.sound.PlaySE (moveSound); 
			UpdatePosition ();
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			switch (id) {
			case 0:
				break;
			case 1:
				break;
			case 2:
				world.sound.PlaySE (moveSound);
				Application.Quit ();
				break;
			}
		}

		if (Input.GetButtonDown ("Fire1")) {   
			Collider2D[] col = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint (Input.mousePosition));

			if (col.Length > 0) {
				foreach (Collider2D c in col) {
					Debug.Log ("Collider2D" + c.name);
					world.sound.PlaySE (moveSound);
					if (c.name == "Exit") {
						Debug.Log ("Exit Game");
						Application.Quit ();
					} else if (c.name == "New") {
						Debug.Log ("New Game");
						Game.Screen ().FadeAndGo ("Map");
						this.enabled = false;
					} else if (c.name == "Load") {
						Debug.Log ("Load Game");
					}
						
				}
			}
		}
	}

	void UpdatePosition ()
	{
		Vector3 pos = hand.position;
		pos.y = buttons [id].position.y - 0.22f;
		pos.x = xOffset [id];
		hand.position = pos;
	}
}

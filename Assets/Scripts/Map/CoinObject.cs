using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{

	public int amount = 1;

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("OnCollisionEnter2D:"+col.collider.tag);
		if (col.collider.tag != "Player") {
			return;
		}
		Game.sav.GainMoney (1);
		GetComponent<Animator> ().SetTrigger ("Eat");
		Destroy (this);
	}
}

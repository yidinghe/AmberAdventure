using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTitle : World {

	public GameObject btns;
	public GameObject anyKeyText;

	void Update () {
		if (Input.anyKey) {
			btns.SetActive (true);
			anyKeyText.SetActive (false);
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Transform player;
	Collider bound;

	void Awake(){
		player = GameObject.FindWithTag ("Player").transform;
		bound = GameObject.Find ("CamRange").GetComponent<Collider> ();
	}

	void Update(){
		
		float offsetY = -transform.position.z/Mathf.Pow(3f,0.5f) ;
		float offsetX = offsetY*((Screen.width+0f)/(Screen.height+0f)) ;
		Vector3 min = bound.bounds.min ;
		Vector3 max = bound.bounds.max ;

		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(player.position.x, min.x+offsetX, max.x-offsetX) ;
		pos.y = Mathf.Clamp(player.position.y, min.y+offsetY, max.y-offsetY) ;
		transform.position = pos ;
	}

}

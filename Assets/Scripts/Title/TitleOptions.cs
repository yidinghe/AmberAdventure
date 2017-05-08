using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOptions : MonoBehaviour {

	public Transform hand ;
	public Transform[] buttons ;
	public float[] xOffset ;
	int id = 0 ;

	// Use this for initialization
	void Start () {
		id = 1 ;
		UpdatePosition() ;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			id -- ;
			id = Mathf.Clamp(id,0 ,2) ;
			UpdatePosition() ;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			id ++ ;
			id = Mathf.Clamp(id,0 ,2) ;
			UpdatePosition() ;
		}
	}

	void UpdatePosition(){
		Vector3 pos = hand.position ;
		pos.y = buttons[id].position.y-0.22f ;
		pos.x = xOffset[id] ;
		hand.position = pos ;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour {
	Button test;
	// Use this for initialization
	void Start () {
		test = transform.GetComponent<Button> ();
		EventTriggerListener.Get (test.gameObject).onClick = OnButtonClick;
	}
	private void OnButtonClick(GameObject go) {  
		//在这里监听按钮的点击事件  
		if (go == test.gameObject) {  
			Debug.Log ("button_run");  

		}  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

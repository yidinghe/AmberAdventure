using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

	public string sceneName = "";
	public int sceneId = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoTo (){
		if (sceneName == "") {
			SceneManager.LoadScene (sceneId);
		} else {
			SceneManager.LoadScene (sceneName);
		}
	}
}

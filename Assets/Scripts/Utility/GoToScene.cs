using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

	public string sceneName = "";
	public int sceneId = 0;

	public void GoTo (){
		if (sceneName == "") {
			SceneManager.LoadScene (sceneId);
		} else {
			SceneManager.LoadScene (sceneName);
		}
	}
}

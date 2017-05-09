using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScene : MonoBehaviour
{

	public string sceneName = "";
	public int sceneId = 0;

	public void GoTo ()
	{
		if (sceneName == "") {
			Game.Screen ().FadeAndGo (sceneId);
		} else {
			Game.Screen ().FadeAndGo (sceneName);
		}
	}
}

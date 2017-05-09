using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
	public static ScreenUI Screen ()
	{
		return UnityEngine.Object.FindObjectOfType<ScreenUI> ();
	}
}


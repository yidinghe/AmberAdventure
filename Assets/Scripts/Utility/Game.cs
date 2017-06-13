using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
	public static SaveData sav = new SaveData() ;
	public static bool isTurnOnDebug = true;

	public static ScreenUI Screen ()
	{
		return UnityEngine.Object.FindObjectOfType<ScreenUI> ();
	}
}


public class SaveData{

	public float maxHp = 5f ;
	public float hp = 2.5f ;
	public float maxSp  = 500f;
	public float sp = 500f ;
	public int money = 0 ;
}

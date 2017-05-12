using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{

	public GameObject controlPanel;
	// Use this for initialization
	void Start ()
	{
		if (Game.isTurnOnDebug) {
			controlPanel.SetActive (true);
		} else {
			controlPanel.SetActive (Input.touchSupported);	
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

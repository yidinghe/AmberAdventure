using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	internal SoundManager sound;

	public void Awake(){
		// FindObjectOfType 缓慢, 不要用到update
		sound = FindObjectOfType<SoundManager> ();
	}
}

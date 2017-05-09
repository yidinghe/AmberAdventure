using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource bgm;
	public AudioSource se;

	public void PlaySE(AudioClip au){
		se.PlayOneShot (au);
	}
}

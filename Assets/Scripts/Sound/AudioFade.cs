using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{

	public bool fadeIn = true;
	public float fadeInDuration = 1f;
	[Range (0f, 1f)] public float fadeInVolume = 1;

	public bool fadeOut = true;
	public float fadeOutDuration = 1f;
	[Range (0f, 1f)] public float fadeOutVolume = 0;

	private AudioSource au;

	void Awake ()
	{
		au = GetComponent<AudioSource> ();
		if (au == null) {
			Debug.Log ("cannot find AudioSource");
			this.enabled = false;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (au.isPlaying) {

			if (fadeIn && (au.time <= fadeInDuration + 0.1)) {
				au.volume = fadeInVolume * (au.time / fadeInDuration);
			}

			if (fadeOut && (au.time >= (au.clip.length - fadeOutDuration))) {
				au.volume = (fadeInVolume - fadeOutVolume) * ((au.clip.length - au.time) / fadeOutDuration) + fadeOutVolume;
			}
		}
	}
}

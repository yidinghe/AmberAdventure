using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenUI : MonoBehaviour
{
	public Image black;
	public float speed = -0.12f;

	public void Awake ()
	{
		FadeIn ();
	}

	public void Update ()
	{
		Color c = black.color;
		c.a += speed;
		c.a = Mathf.Clamp01 (c.a);
		black.color = c;
	}

	public void FadeIn ()
	{
		Color c = black.color;
		c.a = 1;
		black.color = c;
		speed = -Mathf.Abs (speed);
	}

	public void FadeOut ()
	{
		Color c = black.color;
		c.a = 0;
		black.color = c;
		speed = Mathf.Abs (speed);
	}

	public void FadeAndGo (string map)
	{
		StartCoroutine (Go (map));
	}

	public void FadeAndGo (int map)
	{
		StartCoroutine (Go (map));
	}

	IEnumerator Go (string map)
	{
		FadeOut ();
		yield return new WaitForSeconds (0.7f);
		SceneManager.LoadScene (map);
	}

	IEnumerator Go (int map)
	{
		FadeOut ();
		yield return new WaitForSeconds (0.7f);
		SceneManager.LoadScene (map);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class MainUI : MonoBehaviour {

	public Transform hearts ;
	public Sprite[] heartImage ;
	public RectTransform sp ;
	public Text coinText ;

	void Awake(){
		DrawMaxHP() ;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DrawSP ();
	}

	void DrawMaxHP(){
		for(int i=1 ; i<Game.sav.maxHp ; i++){
			Transform h = Instantiate(hearts.GetChild(0)) ;
			h.SetParent(hearts, false) ;
			h.name = "h"+(i+1) ;
		}
		DrawHP() ;
	}

	void DrawHP(){
		float hp = Game.sav.hp ;
		foreach(Image img in hearts.GetComponentsInChildren<Image>()){
			img.sprite = heartImage[0] ;
		}

		for(int i=1 ; i<hp ; i++){
			hearts.GetChild(i-1).GetComponent<Image>().sprite = heartImage[2] ;
		}

		if(hp > Mathf.Floor(hp)){
			hearts.GetChild( (int)Mathf.Floor(hp) ).GetComponent<Image>().sprite = heartImage[1] ;
		}
	}

	void DrawSP(){
		float s = Game.sav.sp ;
		sp.sizeDelta = new Vector2(Mathf.Lerp(sp.sizeDelta.x, s, 0.12f), sp.sizeDelta.y);
	}

}

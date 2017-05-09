//======================
// SmomoGame免費腳本
// AudioFade.js
// 自動淡入淡出AudioSource，請放在AudioSource上
// Automatically fade in/out AudioSource, Please attach it to AudioSource
// FB: https://www.facebook.com/smomogame/
// G+: https://plus.google.com/u/0/b/106119424533107839040/106119424533107839040
//======================
#pragma strict
// 自定變數 Custom Variables
var fadeIn : boolean = true ;     // 是否淡入(開始時) Whether to fade in(start)
var fadeInDuration : float = 1 ;  // 淡入時間(秒) Fade in duration
@Range(0f,1f) var fadeInVolume : float = 1 ;  // 淡入目標音量 Fade in target volume
var fadeOut : boolean = true ;    // 是否淡出(結束時) Whether to fade out(end)
var fadeOutDuration : float = 1 ; // 淡出時間(秒) Fade out duration
@Range(0f,1f) var fadeOutVolume : float = 0 ;  // 淡出目標音量 Fade out target volume
// 固定變數 Constant Variables
private var au : AudioSource ;  // AudioSource元件 AudioSource component

// 開始 Awake
function Awake(){
  au = GetComponent.<AudioSource>() ;
  // 偵錯 Debug
  if(au == null){
    Debug.Log("錯誤!找不到AudioSource元件。  Error! GameObject has no AudioSource component.") ;
    this.enabled = false ;
  }
}

function Update(){
  if(au.isPlaying){
    // 淡入 Fade in
    if(fadeIn && (au.time <= fadeInDuration+0.1)){
      au.volume = fadeInVolume*(au.time/fadeInDuration) ;
    }
    // 淡出 Fade out
    if(fadeOut && (au.time >= (au.clip.length-fadeOutDuration))){
      au.volume = (fadeInVolume-fadeOutVolume)*((au.clip.length-au.time)/fadeOutDuration)+fadeOutVolume ;
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt("unlockedLevel", 0);
		if(PlayerPrefs.GetInt("unlockedLevel")<Application.loadedLevel){
			PlayerPrefs.SetInt("unlockedLevel", Application.loadedLevel);
		}
		if(PlayerPrefs.GetInt("unlockedLevel")==0){
			PlayerPrefs.SetInt("unlockedLevel", 2);
		}
	}
	
	
}

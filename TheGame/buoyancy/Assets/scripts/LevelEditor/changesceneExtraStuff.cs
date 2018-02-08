using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesceneExtraStuff : MonoBehaviour {

	
	
	// Update is called once per frame
	public void press() {
		if(save.tempoPlay){
			Time.timeScale = 1;
			Application.LoadLevel(1);
		}
		else{
			Time.timeScale = 1;
			playCustom.jaa = false;
			changeSceneOnline.tempo = false;
			Application.LoadLevel(0);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesceneExtraStuff : MonoBehaviour {

	
	
	// Update is called once per frame
	public void press() {
		if(save.tempoPlay){
			Application.LoadLevel(1);
		}
		else{
			
			playCustom.jaa = false;
			changeSceneOnline.tempo = false;
			Application.LoadLevel(0);
		}
	}
}

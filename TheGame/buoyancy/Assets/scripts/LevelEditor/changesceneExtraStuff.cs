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
			Application.LoadLevel(0);
			changeSceneOnline.tempo = false;
		}
	}
}

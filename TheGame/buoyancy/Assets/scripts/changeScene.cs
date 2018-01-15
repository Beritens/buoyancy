using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

	public int scene;
	public void sceenChange(){
		playCustom.jaa = false;
		save.tempoPlay = false;
		Application.LoadLevel(scene);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour {

	public int scene;
	public void sceenChange(){
		print("hey");
		playCustom.jaa = false;
		save.tempoPlay = false;
		loadLevel.useSaveName = false;
		Application.LoadLevel(scene);
	}
}

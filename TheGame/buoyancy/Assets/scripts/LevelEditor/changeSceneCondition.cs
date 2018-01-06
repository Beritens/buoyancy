using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneCondition : MonoBehaviour {

	public int scene;
	public bool restart = false;
	public openPauseMenu pauseMenu;
	public void sceenChange(){
		if(isSomethingOpen.modified){
			GameObject.Find("QuestionStuff").GetComponent<question>().Anfrage(restart);
			if(Application.loadedLevel == 2){
				pauseMenu.close();
			}
		}
		else{
			playCustom.jaa = false;
			save.tempoPlay = false;
			loadLevel.useSaveName = false;
			Application.LoadLevel(scene);
		}
		
	}
}

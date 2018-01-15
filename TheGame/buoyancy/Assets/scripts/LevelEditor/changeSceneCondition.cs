using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneCondition : MonoBehaviour {

	public int scene;
	public bool restart = false;
	public openSomething pauseMenu;
	public void sceenChange(){
		if(isSomethingOpen.modified){
			GameObject.Find("QuestionStuff").GetComponent<question>().Anfrage(restart);
			if(Application.loadedLevel == 2){
				pauseMenu.close();
			}
		}
		else{
			loadLevel.usesaveName = false;
			playCustom.jaa = false;
			save.tempoPlay = false;
			Application.LoadLevel(scene);
			changeSceneOnline.tempo = false;
		}
		
	}
}

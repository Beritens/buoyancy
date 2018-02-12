using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneCondition : MonoBehaviour {

	public int scene;
	public int restart = 0;
	public bool closeStuff = false;
	public openSomething pauseMenu;
	public openSomething[] windows;
	public openLoadMenu loadMenu;
	public void sceenChange(){
		if(isSomethingOpen.modified){
			
			if(Application.loadedLevel == 2){
				pauseMenu.close();
				Time.timeScale = 0.05f;
			}
			else if(closeStuff){
				for(int i = 0; i<windows.Length; i++){
					windows[i].close();
				}
				if(loadMenu != null){
					loadMenu.close();
				}
				
			}
			GameObject.Find("QuestionStuff").GetComponent<question>().Anfrage(restart);
		}
		else{
			loadLevel.usesaveName = false;
			playCustom.jaa = false;
			save.tempoPlay = false;
			changeSceneOnline.tempo = false;
			Time.timeScale = 1;
			Application.LoadLevel(scene);
			
		}
		
	}
}

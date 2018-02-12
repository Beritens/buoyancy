using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class question : MonoBehaviour {

	public UiAnimation Fenster;
	int load;
	public openSomething savee;
	public bool open;
	public isSomethingOpen isopen;
	public string path;

	
	public void Anfrage(int wtd){
		if(!open){
			open =true;
			load = wtd;
			if(Application.loadedLevel == 1)
				isopen.SomethingOpen = true;
			Fenster.gameObject.SetActive(true);
			Fenster.open();
		}
		

	}
	public void yes(){
		open = false;
		if(Application.loadedLevel == 1)
			isopen.SomethingOpen = false;
		Fenster.close();
		savee.open();
		if(load == 1){
			openFile.jaa = false;
		}
	}
	public void no(){
		open = false;
		isSomethingOpen.modified = false;
		if(load == 1){
			openFile.jaa = true;
			openFile.path = path;
			Time.timeScale = 1;
			Application.LoadLevel(1);
		}
		else if(load == 0){
			loadLevel.usesaveName = false;
			playCustom.jaa = false;
			save.tempoPlay = false;
			changeSceneOnline.tempo = false;
			Time.timeScale = 1;
			Application.LoadLevel(0);
		}
		else if(load == 2){
			loadLevel.usesaveName = false;
			playCustom.jaa = false;
			save.tempoPlay = false;
			changeSceneOnline.tempo = false;
			Time.timeScale = 1;
			Application.LoadLevel(1);
		}
	}
	public void cancle(){
		open = false;
		if(Application.loadedLevel == 1)
			isopen.SomethingOpen = false;
		Fenster.close();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class question : MonoBehaviour {

	public UiAnimation Fenster;
	bool load;
	public openSomething savee;
	bool open;
	isSomethingOpen isopen;

	void Start(){
		isopen = GameObject.Find("Scroller").GetComponent<isSomethingOpen>();
	}
	public void Anfrage(bool lol){
		if(!open){
			open =true;
			load = lol;
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
		StartCoroutine(wait());
		savee.open();
		if(load == true){
			openFile.jaa = false;
		}
	}
	public void no(){
		open = false;
		isSomethingOpen.modified = false;
		if(load){
			Application.LoadLevel(1);
		}
		else{
			playCustom.jaa = false;
			save.tempoPlay = false;
			loadLevel.usesaveName = false;
			Application.LoadLevel(0);
		}
	}
	public void cancle(){
		open = false;
		if(Application.loadedLevel == 1)
			isopen.SomethingOpen = false;
		Fenster.close();
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(2);
		if(!open){
			Fenster.gameObject.SetActive(false);
		}
		
	}
}

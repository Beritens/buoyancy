﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class question : MonoBehaviour {

	public UiAnimation Fenster;
	bool load;
	public openSomething savee;
	bool open;

	public void Anfrage(bool lol){
		if(!open){
			open =true;
			load = lol;
			GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = true;
			Fenster.gameObject.SetActive(true);
			Fenster.open();
		}
		

	}
	public void yes(){
		open = false;
		GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = false;
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
			loadLevel.useSaveName = false;
			Application.LoadLevel(0);
		}
	}
	public void cancle(){
		open = false;
		GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = false;
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
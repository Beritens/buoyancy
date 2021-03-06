﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLoadMenu : MonoBehaviour {

	//public Animator anim;
	bool openn = false;
	public GameObject TheThing;
	public Transform container;
	isSomethingOpen isopen;

	void Start(){
		isopen = GameObject.Find("Scroller").GetComponent<isSomethingOpen>();
	}
	public void open(){
		if(!isopen.SomethingOpen || openn){
			openn = !openn;
		
			//anim.SetBool("open", !anim.GetBool("open"));
			if(openn){
				//anim.SetBool("open", true);
				isopen.SomethingOpen = true;
				TheThing.SetActive(true);
				//anim.Play("open");
				TheThing.GetComponent<UiAnimation>().open();
				TheThing.GetComponent<load>().GetFile();
			}
			else if(!openn){
				//anim.SetBool("open", false);
				foreach (Transform child in container) {
					GameObject.Destroy(child.gameObject);
				}
				isopen.SomethingOpen = false;
				TheThing.GetComponent<UiAnimation>().close();
				StartCoroutine(wait());
			}
		}

		
	}
	
	public void close(){
		foreach (Transform child in container) {
     		GameObject.Destroy(child.gameObject);
 		}
		openn = false;
		isopen.SomethingOpen = false;
		TheThing.GetComponent<UiAnimation>().close();
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(2);
		if(!openn){
			TheThing.SetActive(false);
		}
		
		
	}
}

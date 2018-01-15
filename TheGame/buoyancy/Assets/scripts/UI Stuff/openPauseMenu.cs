using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPauseMenu : MonoBehaviour {

	public bool an = false;
	public GameObject theThing;
	public void open(){
		an = !an;
		
		if(an){
			
			theThing.SetActive(true);
			theThing.GetComponent<UiAnimation>().open();
			//Animator anim = theThing.GetComponent<Animator>();
			//anim.SetBool("open",an);
			//anim.Play("open");
		}
		else{
			theThing.GetComponent<UiAnimation>().close();
			//Animator anim = theThing.GetComponent<Animator>();
			//anim.SetBool("open",an);
			StartCoroutine(wait());
		}
		
	}
	public void close(){
		theThing.GetComponent<UiAnimation>().close();
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(0.5f);
		theThing.SetActive(false);
	}
}

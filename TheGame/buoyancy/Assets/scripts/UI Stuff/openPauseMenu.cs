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
			Animator anim = theThing.GetComponent<Animator>();
			anim.SetBool("open",an);
			anim.Play("open");
		}
		else{
			Animator anim = theThing.GetComponent<Animator>();
			anim.SetBool("open",an);
			theThing.SetActive(false);
		}
		
	}
	public void close(){
		Animator anim = theThing.GetComponent<Animator>();
		an = false;
		anim.SetBool("open",false);
		theThing.SetActive(false);
	}
}

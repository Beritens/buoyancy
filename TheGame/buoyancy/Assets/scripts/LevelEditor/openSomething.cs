using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSomething : MonoBehaviour {

	//public Animator anim;
	public GameObject TheThing;
	public bool openn = false;

	public void open(){
		if(!GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen || openn){
			//anim.SetBool("open", !anim.GetBool("open"));
			openn = !openn;
			if(openn){
				print("hello");
				//anim.SetBool("open", true);
				GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = true;
				TheThing.SetActive(true);
				TheThing.GetComponent<UiAnimation>().open();
				//anim.Play("open");
			}
			else if(!openn){
				//anim.SetBool("open", false);
				TheThing.GetComponent<UiAnimation>().close();
				GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = false;
				StartCoroutine(wait());
			}
			
		}
		
	}
	public void close(){
		//anim.SetBool("open", false);
		openn = false;
		TheThing.GetComponent<UiAnimation>().close();
		GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen = false;
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(2);
		if(!openn){
			TheThing.SetActive(false);
		}
		
	}
}

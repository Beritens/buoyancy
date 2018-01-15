using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSomething : MonoBehaviour {

	//public Animator anim;
	public GameObject TheThing;
	public bool openn = false;
	isSomethingOpen Scroller;
	public bool useIsSonethingOpen = true;
	void Start(){
		if(Application.loadedLevel == 1){
			Scroller = GameObject.Find("Scroller").GetComponent<isSomethingOpen>();
		}
	}

	public void open(){
		if(Application.loadedLevel == 1 && useIsSonethingOpen){
			if(!Scroller.SomethingOpen || openn){
				//anim.SetBool("open", !anim.GetBool("open"));
				openn = !openn;
				if(openn){
					//anim.SetBool("open", true);
					Scroller.SomethingOpen = true;
					TheThing.SetActive(true);
					TheThing.GetComponent<UiAnimation>().open();
					//anim.Play("open");
				}
				else if(!openn){

					//anim.SetBool("open", false);
					TheThing.GetComponent<UiAnimation>().close();
					Scroller.SomethingOpen = false;
					StartCoroutine(wait());
				}
				
			}
		}
		else{
			openn = !openn;
			if(openn){
				print("hi");
				//anim.SetBool("open", true);
				TheThing.SetActive(true);
				TheThing.GetComponent<UiAnimation>().open();
				//anim.Play("open");
			}
			else if(!openn){
				//anim.SetBool("open", false);
				TheThing.GetComponent<UiAnimation>().close();
				StartCoroutine(wait());
			}
		}
		
		
	}
	public void close(){
		//anim.SetBool("open", false);
		openn = false;
		TheThing.GetComponent<UiAnimation>().close();
		if(Application.loadedLevel == 1 && useIsSonethingOpen)
			Scroller.SomethingOpen = false;
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(2);
		if(!openn){
			TheThing.SetActive(false);
		}
		
	}
}

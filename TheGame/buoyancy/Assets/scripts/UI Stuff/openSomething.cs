using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSomething : MonoBehaviour {

	//public Animator anim;
	public GameObject TheThing;
	public bool openn = false;
	isSomethingOpen Scroller;
	public bool useIsSonethingOpen = true;
	public bool useIsSonethingOpenABit = false;
	public bool pause = true;
	void Start(){
		if(Application.loadedLevel == 1){
			Scroller = GameObject.Find("Scroller").GetComponent<isSomethingOpen>();
		}
	}

	public void open(){
		if(Application.loadedLevel == 1 && useIsSonethingOpen){
			if(!Scroller.SomethingOpen || openn){
				print(Scroller.SomethingOpen);
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
				}
				
			}
		}
		else if(useIsSonethingOpenABit){
			openn = !openn;
			if(openn && !Scroller.SomethingOpen){
				//anim.SetBool("open", true);
				TheThing.SetActive(true);
				TheThing.GetComponent<UiAnimation>().open();
				//anim.Play("open");
			}
			else if(openn && Scroller.SomethingOpen){
				openn = false;
			}
			else if(!openn){
				//anim.SetBool("open", false);
				TheThing.GetComponent<UiAnimation>().close();
				//StartCoroutine(wait());
			}
		}
		else{
			openn = !openn;
			if(openn){
				//anim.SetBool("open", true);
				TheThing.SetActive(true);
				TheThing.GetComponent<UiAnimation>().open();
				if(pause){
					Time.timeScale = 0.05f;
				}
				//anim.Play("open");
			}
			else if(!openn){
				//anim.SetBool("open", false);
				TheThing.GetComponent<UiAnimation>().close();
				//StartCoroutine(wait());
				if(pause){
					Time.timeScale = 1;
				}
			}
		}
		
		
	}
	public void close(){
		if(openn){
			//anim.SetBool("open", false);
			openn = false;
			TheThing.GetComponent<UiAnimation>().close();
			if(Application.loadedLevel == 1 && useIsSonethingOpen){
				Scroller.SomethingOpen = false;
			}
			else if(pause){
				Time.timeScale = 1;
			}
				
			//StartCoroutine(wait());
		}
		
	}
}

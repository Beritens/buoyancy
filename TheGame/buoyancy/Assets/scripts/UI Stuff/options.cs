using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour {

	bool aktiviert = false;
	public GameObject panel;
	public GameObject panelChild;
	

	// Use this for initialization
	public void open(){
		aktiviert = !aktiviert;
		
		if(aktiviert == false){
			//anim.SetBool("active", false);

			panelChild.GetComponent<UiAnimation>().close();
			StartCoroutine(wait());
			GetComponent<UianimRot>().rotate1();
			print("lol");
			//panel.GetComponent<mobileSlider>().enabled = false;
		}
		else{
			panel.SetActive(true);
			panelChild.SetActive(true);
			panelChild.GetComponent<UiAnimation>().open();
			GetComponent<UianimRot>().rotate2();
			
			//anim.SetBool("active", true);
			//anim.Play("open panel");
		}
		
		
	}
	IEnumerator wait(){
		yield return new WaitForSeconds(0.2f);
		if(!aktiviert){
			panel.SetActive(false);
		}
		
	}
	/*void Update(){
		if(aktiviert){
			if(panelChild.GetComponentInChildren<RectTransform>().anchorMin.x == 0){
				panel.GetComponent<mobileSlider>().enabled = true;
			}
		}
		
	}*/
}

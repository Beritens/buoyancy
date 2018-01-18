using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openColorStuff : MonoBehaviour {

	public GameObject color;
	public Image bg1;
	public Image bg2;
	public FarbenLager cam;
	public void press () {
		if(color.activeSelf){
			bg1.color = cam.bg1;
			bg2.color = cam.bg2;
			if(GameObject.Find("sizeStuff(Clone)")){
				color.GetComponent<COLOR>().change(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.GetComponent<SpriteRenderer>().color, false);
			}
			
		}
	}
	public void changebgColor(){
		bg1.color = cam.bg1;
		bg2.color = cam.bg2;
	}
}

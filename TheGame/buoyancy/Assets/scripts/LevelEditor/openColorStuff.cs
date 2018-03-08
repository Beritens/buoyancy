using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openColorStuff : MonoBehaviour {

	public GameObject color;
	public FarbenLager cam;
	public void press () {
		if(color.activeSelf){
			//bg1.color = cam.bg1;
			//bg2.color = cam.bg2;
			if(GameObject.Find("sizeStuff(Clone)")){
				Transform square = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
				if(square.tag != "group"){
					color.GetComponent<COLOR>().change(square.GetComponent<SpriteRenderer>().color, false);
				}
				
			}
			
		}
	}
	/*public void changebgColor(){
		bg1.color = cam.bg1;
		bg2.color = cam.bg2;
	}*/
}

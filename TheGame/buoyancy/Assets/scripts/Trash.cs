using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public bool  trashOpen = false;

	
	// Update is called once per frame
	public void click () {
		trashOpen = !trashOpen;
		if(trashOpen){
			if(GetComponent<Image>()){
				GetComponent<Image>().sprite = sprite2;
			}
		}
		else{
			if(GetComponent<Image>()){
				GetComponent<Image>().sprite = sprite1;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modis : MonoBehaviour {

	public bool scaleOn = true;
	public bool moveOn = true;
	public bool rotateOn = true;
	public GameObject scaleMode;
	public GameObject moveMode;
	public GameObject bothMode;
	public GameObject rotateMode;
	public Color on;
	public Color off;
	void Start(){
		scaleOn = true;
		moveOn = true;
		rotateOn = false;
		scaleMode.GetComponent<Image>().color = off;
		moveMode.GetComponent<Image>().color = off;
		bothMode.GetComponent<Image>().color = on;
		rotateMode.GetComponent<Image>().color = off;
	}


	public void scale () {
		if(!scaleOn || (moveOn && scaleOn)){
			scaleOn = true;
			scaleMode.GetComponent<Image>().color = on;
		}
		else{
			scaleOn = false;
			scaleMode.GetComponent<Image>().color = off;
		}
		moveOn = false;
		rotateOn = false;
		
		
		moveMode.GetComponent<Image>().color = off;
		bothMode.GetComponent<Image>().color = off;
		rotateMode.GetComponent<Image>().color = off;
	}
	public void move () {
		if(!moveOn || (moveOn && scaleOn)){
			moveOn = true;
			moveMode.GetComponent<Image>().color = on;
		}
		else{
			moveOn = false;
			moveMode.GetComponent<Image>().color = off;
		}
		scaleOn = false;
		rotateOn = false;
		scaleMode.GetComponent<Image>().color = off;
		
		bothMode.GetComponent<Image>().color = off;
		rotateMode.GetComponent<Image>().color = off;
		
	}
	public void both () {
		if(!scaleOn || !moveOn){
			scaleOn = true;
			moveOn = true;
			bothMode.GetComponent<Image>().color = on;
		}
		else{
			scaleOn = false;
			moveOn = false;
			bothMode.GetComponent<Image>().color = off;
		}
		
		rotateOn = false;
		scaleMode.GetComponent<Image>().color = off;
		moveMode.GetComponent<Image>().color = off;
		
		rotateMode.GetComponent<Image>().color = off;
	}
	public void rotate(){
		scaleOn = false;
		moveOn = false;
		rotateOn = !rotateOn;
		scaleMode.GetComponent<Image>().color = off;
		moveMode.GetComponent<Image>().color = off;
		bothMode.GetComponent<Image>().color = off;
		if(rotateOn){
			rotateMode.GetComponent<Image>().color = on;
		}
		else{
			rotateMode.GetComponent<Image>().color = off;
		}
	}
}

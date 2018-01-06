using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class mobileSlider : MonoBehaviour {

	public RectTransform knob;
	public RectTransform slider;
	private float targetPosX;
	public float wert;
	public bool JAA;

	public RectTransform lefty;
	public RectTransform righty;
	public RectTransform jumpi;
	
	bool ok = false;
	void Start () {

		if(!PlayerPrefs.HasKey("buttonSize"))
		 {
 			PlayerPrefs.SetFloat("buttonSize",0.5f);
		 }
		wert=PlayerPrefs.GetFloat("buttonSize");
		knob.anchorMax = new Vector2(wert+0.05f,1.75f);
		knob.anchorMin = new Vector2(wert-0.05f,-0.75f);
		//targetPos = knob.position;
		
	}
	/*void OnEnable(){
		if(!PlayerPrefs.HasKey("buttonSize"))
		 {
 			PlayerPrefs.SetFloat("buttonSize",0.5f);
		 }
		wert=PlayerPrefs.GetFloat("buttonSize");

		//knob.position = new Vector3((slider.position.x-slider.rect.width/2)+(wert*slider.rect.width),knob.position.y,knob.position.z);
		knob.anchorMax = new Vector2(wert+0.05f,1.75f);
		knob.anchorMin = new Vector2(wert-0.05f,-0.75f);
		//targetPos = knob.position;
	}*/
	public void down(){
		ok  = true;
	}
	public void up(){
		ok  = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touchCount ==1 && (Input.GetTouch(0).phase == TouchPhase.Stationary||Input.GetTouch(0).phase == TouchPhase.Moved) && ok){
			//targetPos = new Vector3(Mathf.Clamp(Input.GetTouch(0).position.x,Screen.width*0.5f,Screen.width*0.76f),targetPos.y,targetPos.z);
			targetPosX = Mathf.Clamp(Input.GetTouch(0).position.x, slider.position.x-slider.rect.width/2 , slider.position.x+slider.rect.width/2);
			print(slider.position.x +" "+ slider.rect.width);
			
			wert =(targetPosX-(slider.position.x-slider.rect.width/2))/(slider.rect.width);
			knob.anchorMax = new Vector2(wert+0.05f,1.75f);
			knob.anchorMin = new Vector2(wert-0.05f,-0.75f);
			lefty.anchorMax = new Vector2((wert*0.25f+0.05f)+0.02f,(wert*0.25f+0.05f)+0.02f);
			righty.anchorMin = new Vector2((wert*0.25f+0.05f)+0.04f,0.02f);
			righty.anchorMax = new Vector2((wert*0.25f+0.05f)*2+0.04f,(wert*0.25f+0.05f)+0.02f);
			jumpi.anchorMin =new Vector2(1-((wert*0.25f+0.05f)+0.02f),0.02f);
			jumpi.anchorMax =new Vector2(0.98f,(wert*0.25f+0.05f)+0.02f);
		}
		PlayerPrefs.SetFloat("buttonSize",wert);
	}
	/*void OnTouchStay(Vector3 point){
		print("yay");
		targetPos = new Vector3(point.x,targetPos.y,targetPos.z);
		
		
	}*/
}

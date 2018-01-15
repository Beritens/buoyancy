using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour {

	public bool left = false;
	public bool right = false;
	public RectTransform lefty;
	public RectTransform righty;
	public RectTransform jumpi;
	GameObject[] Player;
	public float leftorright = 0;
	float bsize;
	public void addPlayers(){
		Player = GameObject.FindGameObjectsWithTag("Player");
	}
	void Start(){
		Player = GameObject.FindGameObjectsWithTag("Player");
		if(!PlayerPrefs.HasKey("buttonSize"))
		 {
 			PlayerPrefs.SetFloat("buttonSize",0.5f);
		 }
		bsize = PlayerPrefs.GetFloat("buttonSize");
		lefty.anchorMax = new Vector2((bsize*0.25f+0.05f)+0.02f,(bsize*0.25f+0.05f)+0.02f);
		righty.anchorMin = new Vector2((bsize*0.25f+0.05f)+0.04f,0.02f);
		righty.anchorMax = new Vector2((bsize*0.25f+0.05f)*2+0.04f,(bsize*0.25f+0.05f)+0.02f);
		jumpi.anchorMin =new Vector2(1-((bsize*0.25f+0.05f)+0.02f),0.02f);
		jumpi.anchorMax =new Vector2(0.98f,(bsize*0.25f+0.05f)+0.02f);
	}
	public void leftOn(){
		left = true;
		
		if(right){
			leftorright = 0;
		}
		else{
			leftorright = -1;
		}
		
	}
	public void leftOff(){
		left = false;
		if(right){
			leftorright = 1;
		}
		else{
			leftorright = 0;
		}
	}
	public void rightOn(){
		right = true;
		if(left){
			leftorright = 0;
		}
		else{
			leftorright = 1;
		}
	}
	public void rightOff(){
		right = false;
		if(left){
			leftorright = -1;
		}
		else{
			leftorright = 0;
		}
		
	}
	public void jumpy(){
		
		for(int i = 0; i < Player.Length; i++){
			Player[i].GetComponent<move>().Jump();
		}
	}
}

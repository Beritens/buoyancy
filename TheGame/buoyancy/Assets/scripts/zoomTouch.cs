using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTouch : MonoBehaviour {

	public float zoomSpeed = 1f;
	GameObject cameraa;
	List<Touch> touches = new List<Touch>();
	float bsize;

	void Start(){
		
		cameraa = GameObject.Find("Main Camera");
	}
	void Update(){
		
		if(Input.touchCount >= 2){
			for(int i=Input.touchCount-1;i>=0;i--){
				bsize = PlayerPrefs.GetFloat("buttonSize");
				if(Input.GetTouch(i).position.y > Screen.height*((bsize*0.25f+0.07f)) ||(Input.GetTouch(i).position.x > Screen.width*((bsize*0.25f+0.07f)*2) && Input.GetTouch(i).position.x < Screen.width*(1-(bsize*0.25f+0.07f)))){
					print(i);
					touches.Add(Input.GetTouch(i));

				}
			}
		}
		//print(touches.Count);
		if(touches.Count == 2){
			Vector2 t0prevpos = touches[0].position - touches[0].deltaPosition;
			Vector2 t1prevpos = touches[1].position - touches[1].deltaPosition;

			float prevdistance = Vector2.Distance(t0prevpos,t1prevpos);
			float distance = Vector2.Distance(touches[0].position,touches[1].position);

			float distancedediff = prevdistance - distance;

			cameraa.GetComponent<Camera>().orthographicSize += distancedediff * zoomSpeed;
			cameraa.GetComponent<Camera>().orthographicSize = Mathf.Clamp(cameraa.GetComponent<Camera>().orthographicSize, 3,40);
			//touches.Clear();
		}
		//else if(touches.Count >2){
			
		//}
		touches.Clear();
	}
	
}

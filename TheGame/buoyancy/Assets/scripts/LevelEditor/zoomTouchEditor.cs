using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTouchEditor : MonoBehaviour {

	public float zoomSpeed = 1f;
	GameObject cam;

	float initdistance;
	Vector3 initcamPosition;
	float initorthoSize;
	Vector3 middlePos;
	Vector2 initTouch;

	void Start(){
		
		cam = GameObject.Find("Main Camera");
	}
	void Update(){
		if(Input.touchCount == 2 && !GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen){
			Touch t1 = Input.GetTouch(0);
			Touch t2 = Input.GetTouch(1);
			
			if(t2.phase == TouchPhase.Began){
				initdistance = Vector2.Distance(t1.position,t2.position);
				initcamPosition = cam.transform.position;
				initorthoSize = cam.GetComponent<Camera>().orthographicSize;
				middlePos = cam.GetComponent<Camera>().ScreenToWorldPoint((t1.position+t2.position)/2);
				initTouch = (t1.position+t2.position)/2;

			}
			if(t1.phase == TouchPhase.Moved || t1.phase == TouchPhase.Stationary || t2.phase == TouchPhase.Moved || t2.phase == TouchPhase.Stationary){
				
				Vector2 pos = (t1.position+t2.position)/2;
				float deltaX = initTouch.x - pos.x;
				float deltaY = initTouch.y - pos.y;

				Vector3 scrollAmount = new Vector3((cam.GetComponent<Camera>().orthographicSize*2*Screen.width/Screen.height)/(Screen.width/deltaX),(cam.GetComponent<Camera>().orthographicSize*2)/(Screen.height/deltaY),0);
				
				float distanceNow = Vector2.Distance(t1.position,t2.position);
				float multiplier = distanceNow / initdistance;
				cam.GetComponent<Camera>().orthographicSize = Mathf.Clamp(initorthoSize/multiplier,0,40);
				cam.transform.position = Vector3.Lerp(new Vector3(middlePos.x,middlePos.y,-10),initcamPosition,1/multiplier) + scrollAmount;

			}
			/*Vector2 t0prevpos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
			Vector2 t1prevpos = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;

			float prevdistance = Vector2.Distance(t0prevpos,t1prevpos);
			float distance = Vector2.Distance(Input.GetTouch(0).position,Input.GetTouch(1).position);

			float distancedediff = prevdistance - distance;

			cameraa.GetComponent<Camera>().orthographicSize += distancedediff * zoomSpeed;
			cameraa.GetComponent<Camera>().orthographicSize = Mathf.Clamp(cameraa.GetComponent<Camera>().orthographicSize, 0.001f,40);*/
		}
	}
	
}

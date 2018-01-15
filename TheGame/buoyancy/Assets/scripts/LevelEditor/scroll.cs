using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class scroll : MonoBehaviour {

	public bool canIscroll = true;
	public bool canIscroll2 = true;
	bool kk = true;
	public Transform cam;
	Vector3 initCam;
	Vector2 initTouch;
	
	Vector3 difference;
	bool delete = false;
	bool bruh = false;
	float deleteDistance;
	GameObject Scroller;
	public float ScreendeleteDistance = 100;
	public open PleaseOpenTheMenu;
	void Start () {
		deleteDistance = Screen.width/ScreendeleteDistance;
		Scroller = GameObject.Find("Scroller");

	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.touchCount > 1 ){
			kk = false;
		}*/
		if(Input.touchCount == 0){
			kk = true;
		}
		//print(canIscroll +" lol "+ canIscroll2);
		if(kk && !Scroller.GetComponent<isSomethingOpen>().SomethingOpen){
			if(Input.touchCount == 1){
				Touch touch = Input.GetTouch(0);
				if(touch.phase == TouchPhase.Began || bruh){
					if(EventSystem.current.IsPointerOverGameObject(0)){
						kk = false;
						return;
					}

					delete = false;
					initTouch = touch.position;
					initCam = cam.position;
					
					//RayStuff
					Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
				/*	if(touch.position.y > Screen.height * 0.35f){
						kk = false;
					}*/
					
					if (!Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward) && GameObject.Find("sizeStuff(Clone)") && !bruh) {
						//if((touch.position.x < Screen.width*0.9f || touch.position.y < Screen.height*0.6f || touch.position.y > Screen.height*0.72f)
						//&& (touch.position.x < Screen.width*0.73f || touch.position.y < Screen.height*0.37f || touch.position.y > Screen.height*0.45f)){
						if(!EventSystem.current.IsPointerOverGameObject(0)){
							delete = true;
							print("kkkkkkkkkk");
							
						}
						
					
					}
					else{
						delete = false;
					}
					bruh = false;

				}
				else if(touch.phase == TouchPhase.Moved && canIscroll && canIscroll2){
					
					Scrolling(touch.position);

				}
				else if(touch.phase == TouchPhase.Ended && delete){

					if(GameObject.Find("sizeStuff(Clone)")){
						GameObject sizeStuff = GameObject.Find("sizeStuff(Clone)");
						sizeStuff.GetComponent<sizeThing>().square.gameObject.layer = 0;
						if(PleaseOpenTheMenu.GetComponent<open>().opeeen){
							PleaseOpenTheMenu.GetComponent<open>().closeTheMenu();
						}
						
						if(sizeStuff.GetComponent<sizeThing>().square.Find("outline")){
							sizeStuff.GetComponent<sizeThing>().square.Find("outline").gameObject.SetActive(false);
						}
						
						
						print("miau");
						GameObject.Destroy(sizeStuff);
					}

				}
			}
			else if(Input.touchCount == 2){
				if(Input.GetTouch(1).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Ended){
					bruh = true;
				}
			}
		
		}
		
	}

	void Scrolling(Vector2 pos){
		float deltaX = initTouch.x - pos.x;
		float deltaY = initTouch.y - pos.y;
		
		
		cam.position = new Vector3(initCam.x+(cam.GetComponent<Camera>().orthographicSize*2*Screen.width/Screen.height)/(Screen.width/deltaX),initCam.y+(cam.GetComponent<Camera>().orthographicSize*2)/(Screen.height/deltaY),-10);

		
		if(delete && Mathf.Abs(deltaX) >= deleteDistance || Mathf.Abs(deltaY) >= deleteDistance){
			delete = false;
		}
	}
}

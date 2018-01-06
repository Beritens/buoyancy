using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Drag : MonoBehaviour {

	public Vector3 difference;
	public bool ok = false;
	GameObject Scroller;
	public bool scaleThing;
	public bool moveThing;
	modis mode;
	public LayerMask maski;
	
	

	void Start(){
		mode = GameObject.Find("MODE").GetComponent<modis>();
		Scroller = GameObject.Find("Scroller");
	}
	void Update(){
		
		if(scaleThing){
			if(mode.scaleOn){
				
				Stuff();
			}
			
		}
		else if(moveThing){
			if(mode.moveOn){
				Stuff();
			}
		}
		else{
			Stuff();
		}
		
	}
	void Stuff(){
		if(Input.touchCount == 1 && !Scroller.GetComponent<isSomethingOpen>().SomethingOpen ){
			Touch touch = Input.GetTouch(0);

			Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
			Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
			
			
			if(touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0)){
				
				
				
				
				RaycastHit2D[] hitInformation = Physics2D.RaycastAll(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, maski);
				if (hitInformation.Length > 0) {
					
					for(int i = 0; i<hitInformation.Length;i++){
						GameObject touchedObject = hitInformation[i].transform.gameObject;
					 	if(touchedObject == this.gameObject){
							difference = new Vector3(transform.position.x-touchPos.x,transform.position.y-touchPos.y,-10);
				 			ok = true;
							isSomethingOpen.modified = true;
							//print("yrah");
							Scroller.GetComponent<scroll>().canIscroll2 = false;
							if(GameObject.Find("sizeStuff(Clone)")){
								Scroller.GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
							}
							
							break;
						}
					}
                 
                 
             	}
				else{
					ok = false;
				}

				/*RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
				if (hitInformation.collider != null) {
					
                 GameObject touchedObject = hitInformation.transform.gameObject;
				 if(touchedObject == this.gameObject){
					difference = new Vector3(transform.position.x-touchPos.x,transform.position.y-touchPos.y,-10);
				 	ok = true;
					 Scroller.GetComponent<scroll>().canIscroll2 = false;
				 }
                 
             	}*/
			 
			}
			if(touch.phase == TouchPhase.Ended){
				
				if(GameObject.Find("sizeStuff(Clone)") && ok){
					Scroller.GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
				}
				
				 ok = false;
				 Scroller.GetComponent<scroll>().canIscroll2 = true;
				
            }
			
			if(ok){
				if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
					transform.position = new Vector3(touchPos.x,touchPos.y,0)+new Vector3(difference.x,difference.y,transform.position.z);
				}
			}
		}
		
	}
	
}

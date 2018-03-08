using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public modis mode;
	GameObject Scroller;
	public bool ok;
	public LayerMask maski;
	Quaternion IhopeThisWorks;
	optionStuff optionStuff;
	public Vector2 localCenter;
	Vector2 Center;
	void Start () {
		mode = GameObject.Find("MODE").GetComponent<modis>();
		Scroller = GameObject.Find("Scroller");
		optionStuff = GameObject.Find("openOptionWindow").GetComponent<optionStuff>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount == 1 && !Scroller.GetComponent<isSomethingOpen>().SomethingOpen){


			Touch touch = Input.GetTouch(0);
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
			Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);

				if(touch.phase == TouchPhase.Began ){
					RaycastHit2D[] hitInformation = Physics2D.RaycastAll(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, maski);
				if (hitInformation.Length > 0) {
					
					for(int i = 0; i<hitInformation.Length;i++){
						GameObject touchedObject = hitInformation[i].transform.gameObject;
						if(touchedObject == this.gameObject){
							print("HELP");
							ok = true;
							
							if(tag == "group"){
								Center = transform.TransformPoint(localCenter);
								Vector3 lol = touchPos - (Vector3)Center;
								IhopeThisWorks = Quaternion.LookRotation(transform.forward,lol) * Quaternion.Inverse(transform.rotation);
								Scroller.GetComponent<undo>().add(gameObject, 15, true);
							}
							else{
								Vector3 lol = touchPos - transform.position;
								IhopeThisWorks = Quaternion.LookRotation(transform.forward,lol) * Quaternion.Inverse(transform.rotation);
								Scroller.GetComponent<undo>().add(gameObject, 3, true);
							}
							
							Scroller.GetComponent<scroll>().canIscroll2 = false;
							
							break;
						}
					}
				
				
				}
				else{
					ok = false;
				}
			}
			if(ok){
				if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary){
					
					if(tag == "group"){
						Vector3 relativPosition = touchPos - transform.TransformPoint(localCenter);
						Quaternion rotation1 = Quaternion.LookRotation(transform.forward,relativPosition);
						transform.rotation = rotation1 * Quaternion.Inverse(IhopeThisWorks);
						transform.position -= transform.TransformPoint(localCenter) - (Vector3)Center;
						optionStuff.changePosition();
					}
					else{
						Vector3 relativPosition = touchPos - transform.position;
						Quaternion rotation1 = Quaternion.LookRotation(transform.forward,relativPosition);
						transform.rotation = rotation1 * Quaternion.Inverse(IhopeThisWorks);
					}
					
					optionStuff.changeRotation();
				}
			}
			
			if(touch.phase == TouchPhase.Ended && ok){
				print("hihihihi");
				if(tag == "group")
					Scroller.GetComponent<undo>().add(gameObject, 15, false);
				else
					Scroller.GetComponent<undo>().add(gameObject, 3, false);
				Scroller.GetComponent<scroll>().canIscroll2 = true;
				ok = false;
			}
		
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public modis mode;
	GameObject Scroller;
	public bool ok;
	public LayerMask maski;
	Quaternion IhopeThisWorks;
	void Start () {
		mode = GameObject.Find("MODE").GetComponent<modis>();
		Scroller = GameObject.Find("Scroller");
	}
	
	// Update is called once per frame
	void Update () {
		if(mode.rotateOn){
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
								Vector3 lol = touchPos - transform.position;
								IhopeThisWorks = Quaternion.LookRotation(transform.forward,lol) * Quaternion.Inverse(transform.rotation);
								Scroller.GetComponent<scroll>().canIscroll2 = false;
								Scroller.GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
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
						Vector3 relativPosition = touchPos - transform.position;
						Quaternion rotation1 = Quaternion.LookRotation(transform.forward,relativPosition);
						transform.rotation = rotation1 * Quaternion.Inverse(IhopeThisWorks);
					}
				}
				
				if(touch.phase == TouchPhase.Ended){
					print("hihihihi");
					if(GameObject.Find("sizeStuff(Clone)") && ok){
						Scroller.GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
					}
					Scroller.GetComponent<scroll>().canIscroll2 = true;
					ok = false;
				}
			}
		}
	}
}

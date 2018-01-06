using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour {

	public bool ok = false;
	public GameObject sizecontrol;
	GameObject Scroller;
	//ich mache hier mal eine variable hin, die nix hiermit zu tun hat, weil ich zu faul bin eine neues script zu erstellen
	public int ObjectLPos = 0;

	void Start(){
		Scroller = GameObject.Find("Scroller");
	}
	void Update(){
		if(Input.touchCount == 1 && !GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen && ok){
			Touch touch = Input.GetTouch(0);
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
			Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
			Scroller.GetComponent<scroll>().canIscroll2 = false;
			if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
			
			
				transform.position = new Vector3(touchPos.x,touchPos.y,transform.position.z);
			}
			
			/*if(touch.phase == TouchPhase.Began){
				bool nana = false;

				RaycastHit2D[] hitInformation = Physics2D.RaycastAll(touchPosWorld2D, Camera.main.transform.forward);

				if(hitInformation.Length >1 ){
					nana = true;
					if(GameObject.Find("sizeStuff(Clone)")){
						for(int i = 0; i< hitInformation.Length; i++){
							if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square == hitInformation[i].transform){
								nana = false;
								
							}
						}
					}
					else{
						nana = true;
						print("yoyoyoyooy");
					}
					
					
				}
				
				if((hitInformation.Length == 1 || nana)&& (!GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen ||(touch.position.x < Screen.width*0.9f || touch.position.y < Screen.height*0.6f || touch.position.y > Screen.height*0.82f))){
					print(hitInformation[0]);
					GameObject touchedObject = hitInformation[0].transform.gameObject;
					if(touchedObject == this.gameObject){
						//Scroller.GetComponent<scroll>().canIscroll2 = false;
						if(GameObject.Find("sizeStuff(Clone)") && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square != transform){
							
							GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject.layer = 0;
							if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline")){
								GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline").gameObject.SetActive(false);
							}
							
							GameObject.Destroy(GameObject.Find("sizeStuff(Clone)"));
							
						}
						if(GameObject.Find("sizeStuff(Clone)") == null ||(GameObject.Find("sizeStuff(Clone)") != null && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square != transform)){
							GameObject sizeStuff = GameObject.Instantiate(sizecontrol,transform.position,Quaternion.identity);
							sizeStuff.GetComponent<sizeThing>().square = transform;
							if(!GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
								GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().openTheMenu();
							}
							if(transform.Find("outline")){
								transform.Find("outline").gameObject.SetActive(true);
							}
							
							gameObject.layer = 2;
						}
						
						
						
					}
				}
				
				RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
				
				if (hitInformation.collider != null) {
                 GameObject touchedObject = hitInformation.transform.gameObject;
				 print(touchedObject);
				 if(touchedObject == this.gameObject){
					 //Scroller.GetComponent<scroll>().canIscroll2 = false;
					if(GameObject.Find("sizeStuff(Clone)") && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square != transform){
						
						GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject.layer = 0;
						if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline")){
							GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline").gameObject.SetActive(false);
						}
						
						GameObject.Destroy(GameObject.Find("sizeStuff(Clone)"));
						
					}
					if(GameObject.Find("sizeStuff(Clone)") == null ||(GameObject.Find("sizeStuff(Clone)") != null && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square != transform)){
						GameObject sizeStuff = GameObject.Instantiate(sizecontrol,transform.position,Quaternion.identity);
						sizeStuff.GetComponent<sizeThing>().square = transform;
						if(!GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
							GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().openTheMenu();
						}
						if(transform.Find("outline")){
							transform.Find("outline").gameObject.SetActive(true);
						}
						
						gameObject.layer = 2;
					}
					
					
					
				 }
                 
             	}
			 
			}*/
			if(touch.phase == TouchPhase.Ended){
				
				
				Scroller.GetComponent<undo>().add(this.gameObject, true, true);
				
				ok = false;
				isSomethingOpen.modified = true;
				
				Scroller.GetComponent<scroll>().canIscroll = true;
				Scroller.GetComponent<scroll>().canIscroll2 = true;
				this.enabled = false;
				
            }
		}
	}
	
}

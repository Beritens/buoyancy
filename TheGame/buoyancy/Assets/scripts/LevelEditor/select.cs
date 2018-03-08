using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class select : MonoBehaviour {


	
	public LayerMask sizeStuff;
	public GameObject sizeThing;
	GameObject touchedObject;
	bool nana = false;
	bool bruh = false;
	Vector2 difference;
	public float MaxDifference;
	public GameObject WaterStuff;
	public COLOR colorStuff;
	public LayerMask layerMask;
	public open PleaseOpenTheMenu;
	public  optionStuff optionStuff;
	public createGroup createGroup;
	public float maxTime;
	float timey;
	void Update () {
		if(Input.touchCount ==1 && !EventSystem.current.IsPointerOverGameObject(0)){
			Touch touch = Input.GetTouch(0);
			
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				timey = 0;
				nana = false;
				
				
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
				Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);

				
				if(!colorStuff.eyeDropper && !GetComponent<isSomethingOpen>().SomethingOpen){
					
					/*RaycastHit2D[] hits = Physics2D.RaycastAll(touchPosWorld2D, Camera.main.transform.forward);
					if(hits.Length == 1 ){
						
						if(hits[0].transform.tag == "Player" || hits[0].transform.tag == "ground" || hits[0].transform.tag == "water" || hits[0].transform.tag == "obstacle" || hits[0].transform.tag == "goal" || hits[0].transform.tag == "deko"){
							//print("hm");
							if(!hits[0].transform.GetComponent<Draggable>().ok){
								//print("was?");
								touchedObject = hits[0].transform.gameObject;
								nana = true;
							}
							
						}
					}
					else if(hits.Length > 1){
						touchedObject =dasDing(hits);
					}*/

					
					touchPos.z = -10.1f;
					Ray ray = new Ray( touchPos, new Vector3( 0, 0, 1 ));
					RaycastHit2D hit = Physics2D.GetRayIntersection( ray,Mathf.Infinity,layerMask);
					if(hit.collider != null){
						if(hit.transform.tag == "Player" || hit.transform.tag == "ground" || hit.transform.tag == "water" || hit.transform.tag == "obstacle" || hit.transform.tag == "goal" || hit.transform.tag == "deko"){
							//touchedObject = hit.collider.gameObject;
							bruh = true;
							touchedObject = hit.collider.gameObject;
							difference = touch.position;
						}
						
					}

				}
				else if(colorStuff.eyeDropper){
					RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward,0 ,layerMask);
					if(hit.collider != null){
						Color color =hit.collider.GetComponent<SpriteRenderer>().color;
						colorStuff.change(color, true);
						

						

						colorStuff.EYEDROPPER();
					}
				}




				
				
			}
			timey += Time.deltaTime;
			if(bruh && Input.GetTouch(0).phase == TouchPhase.Ended && Vector2.SqrMagnitude(touch.position-difference)  < Screen.height / MaxDifference && timey < maxTime){
				



				if(!colorStuff.eyeDropper && !GetComponent<isSomethingOpen>().SomethingOpen && !EventSystem.current.IsPointerOverGameObject(0)){
					
					Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
					

					
					touchPos.z = Camera.main.transform.position.z;
					/*Ray ray = new Ray( touchPos, new Vector3( 0, 0, 1 ) );
					RaycastHit2D hit = Physics2D.GetRayIntersection( ray );*/
					//if(hit.collider != null){
						//if(hit.transform.tag == "Player" || hit.transform.tag == "ground" || hit.transform.tag == "water" || hit.transform.tag == "obstacle" || hit.transform.tag == "goal" || hit.transform.tag == "deko"){
							
							
							
							/*if(touchedObject.tag == "water"){
								WaterStuff.SetActive(true);
							}
							else{
								WaterStuff.SetActive(false);
							}*/
						createGroup.gameObject.SetActive(true);
					
						if(GameObject.Find("sizeStuff(Clone)")){
							sizeThing sizeThing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
							if(touchedObject.transform.parent != null && sizeThing.square != touchedObject.transform.parent && sizeThing.square.parent != touchedObject.transform.parent){
								sizeThing.reselect(touchedObject.transform.parent);
								optionStuff.select(touchedObject.transform.parent.gameObject);
							}
							else{
								sizeThing.reselect(touchedObject.transform);
							
							
								//ColorStuff(touchedObject.GetComponent<SpriteRenderer>().color);
								if(colorStuff.gameObject.activeSelf){
									colorStuff.change(touchedObject.GetComponent<SpriteRenderer>().color, false);
								}
								optionStuff.select(touchedObject);
							}
							
							
						}
						else{
							spawn();
							optionStuff.select(touchedObject);
						}
						
							
							
						//}
					//}	
					

				}





				/*if((touchedObject != null && nana && !EventSystem.current.IsPointerOverGameObject(0))){
					
					if(GameObject.Find("sizeStuff(Clone)")){
						GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(touchedObject.transform);
						ColorStuff(touchedObject.GetComponent<SpriteRenderer>().color);
						
					}
					else{
						spawn();
					}
				}*/
			}
		}
		
	}
	/*private GameObject dasDing(RaycastHit2D[] k){
		for(int i = k.Length-1; i > -1; i--){
			if(k[i].transform.tag == "Player" || k[i].transform.tag == "ground" || k[i].transform.tag == "water" || k[i].transform.tag == "obstacle" || k[i].transform.tag == "goal" || k[i].transform.tag == "deko"){
				if(!k[i].transform.GetComponent<Draggable>().ok){
					nana = true;
					return(k[i].transform.gameObject);
				}
				
			}
		}
		return(null);
	}*/
	
	void spawn(){
		if(touchedObject.transform.parent != null && !(createGroup.editing && createGroup.groupy == touchedObject.transform.parent)){
			touchedObject = touchedObject.transform.parent.gameObject;
			touchedObject.GetComponent<BoxCollider2D>().enabled = true;
			createGroup.select();
		}
		else {
			if(!(touchedObject.transform.parent != null && createGroup.editing && createGroup.groupy == touchedObject.transform.parent)){
				createGroup.darkThingOff();
				createGroup.state = 0;
				createGroup.editing = false;
				createGroup.textMesh.text = "create group";
			}
			
			if(colorStuff.gameObject.activeSelf){
				colorStuff.change(touchedObject.GetComponent<SpriteRenderer>().color, false);
			}
		}
		GameObject sizeStuff = GameObject.Instantiate(sizeThing,transform.position,Quaternion.identity);
		sizeStuff.GetComponent<sizeThing>().square = touchedObject.transform;
		if(!PleaseOpenTheMenu.opeeen){
			PleaseOpenTheMenu.openTheMenu();
		}
		//ColorStuff(touchedObject.GetComponent<SpriteRenderer>().color);
		
		
		
		
		touchedObject.layer = 8;
	}
	/*void ColorStuff(Color color){
		float h, s, v;
		Color.RGBToHSV(color, out h, out s, out v);
		COLOR colorComponent = GameObject.Find("color picker").GetComponent<COLOR>();
		colorComponent.hue.changePos(h);
		colorComponent.h = h;
		colorComponent.s = s;
		colorComponent.v = v;
		colorComponent.alpha.changePos(color.a);
		colorComponent.a = color.a;
		colorComponent.color = color;
		colorComponent.alphaSlider.color = new Color(color.r,color.g,color.b,1);
		GameObject.Find("color picker").GetComponent<Image>().color = Color.HSVToRGB(h,1,1);
		//GameObject.Find("Scroller").GetComponent<isSomethingOpen>().modified = true;
	}*/

}

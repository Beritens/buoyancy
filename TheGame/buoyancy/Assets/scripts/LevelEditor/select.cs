﻿using System.Collections;
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
	public modis mode;
	public COLOR colorStuff;
	void Update () {
		if(Input.touchCount ==1 && !EventSystem.current.IsPointerOverGameObject(0)){
			Touch touch = Input.GetTouch(0);
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				nana = false;
				
				
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
				Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);

				
				if(!colorStuff.eyeDropper && !GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen){
					
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

					
					touchPos.z = Camera.main.transform.position.z;
					Ray ray = new Ray( touchPos, new Vector3( 0, 0, 1 ) );
					RaycastHit2D hit = Physics2D.GetRayIntersection( ray );
					if(hit.collider != null){
						if(hit.transform.tag == "Player" || hit.transform.tag == "ground" || hit.transform.tag == "water" || hit.transform.tag == "obstacle" || hit.transform.tag == "goal" || hit.transform.tag == "deko"){
							//touchedObject = hit.collider.gameObject;
							bruh = true;
							difference = touch.position;
						}
						
					}

				}
				else if(colorStuff.eyeDropper){
					RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
					if(hit.collider != null){
						Color color =hit.collider.GetComponent<SpriteRenderer>().color;
						colorStuff.change(color);
						

						if(GameObject.Find("sizeStuff(Clone)")){
							Transform square = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
							GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
							
							square.GetComponent<SpriteRenderer>().color = color;
							if(square.tag == "water"){
								square.GetComponent<water>().colorChanged = true;
							}
							isSomethingOpen.modified = true;
							GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
						}

						colorStuff.EYEDROPPER();
					}
				}




				
				
			}
			if(bruh && Input.GetTouch(0).phase == TouchPhase.Ended && Vector2.SqrMagnitude(touch.position-difference)  < Screen.height / MaxDifference){
				



				if(!colorStuff.eyeDropper && !GetComponent<isSomethingOpen>().SomethingOpen && !EventSystem.current.IsPointerOverGameObject(0) && (mode.scaleOn || mode.moveOn || mode.rotateOn)){
					
					Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
					

					
					touchPos.z = Camera.main.transform.position.z;
					Ray ray = new Ray( touchPos, new Vector3( 0, 0, 1 ) );
					RaycastHit2D hit = Physics2D.GetRayIntersection( ray );
					if(hit.collider != null){
						if(hit.transform.tag == "Player" || hit.transform.tag == "ground" || hit.transform.tag == "water" || hit.transform.tag == "obstacle" || hit.transform.tag == "goal" || hit.transform.tag == "deko"){
							
							touchedObject = hit.collider.gameObject;
							
							if(touchedObject.tag == "water"){
								WaterStuff.SetActive(true);
							}
							else{
								WaterStuff.SetActive(false);
							}
					
							if(GameObject.Find("sizeStuff(Clone)")){
								GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(touchedObject.transform);
								//ColorStuff(touchedObject.GetComponent<SpriteRenderer>().color);
								colorStuff.change(touchedObject.GetComponent<SpriteRenderer>().color);
								
							}
							else{
								spawn();
							}
							
							
							
						}
						
					}

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
		GameObject sizeStuff = GameObject.Instantiate(sizeThing,transform.position,Quaternion.identity);
		sizeStuff.GetComponent<sizeThing>().square = touchedObject.transform;
		if(!GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
			GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().openTheMenu();
		}
		if(touchedObject.transform.Find("outline")){
			
			touchedObject.transform.Find("outline").gameObject.SetActive(true);
		}
		//ColorStuff(touchedObject.GetComponent<SpriteRenderer>().color);
		colorStuff.change(touchedObject.GetComponent<SpriteRenderer>().color);
		
		
		//print("no");
		touchedObject.layer = 2;
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

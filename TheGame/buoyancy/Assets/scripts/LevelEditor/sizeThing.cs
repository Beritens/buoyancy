﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeThing : MonoBehaviour {

	public Camera cam;
	public bool IsScaling = false;
	public Transform move;
	public Transform alldots;
	public Transform one;
	public Transform two;
	public Transform three;
	public Transform four;
	public Transform square;
	Transform onea;
	Transform twoa;
	Transform threea;
	Transform foura;
	Transform oneb;
	Transform twob;
	Transform threeb;
	Transform fourb;

	bool beep;
	Vector3 unterschied = new Vector3(0,0,0);
	GameObject Scroller;
	modis mode;
	bool movee;
	bool scalililili = false;

	//bleib beim richtigen
	bool über = true;
	bool links = false;

	void Start(){
		cam= GameObject.Find("Main Camera").GetComponent<Camera>();
		Scroller = GameObject.Find("Scroller");
		mode = GameObject.Find("MODE").GetComponent<modis>();
		
		move.rotation = square.rotation;
		move.localScale = square.localScale;
		move.position = square.position;

		if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko"){
			
			alldots.rotation = move.rotation;

			unterschied =move.position-alldots.position;
			onea = square.transform.GetChild(0);
			twoa = square.transform.GetChild(1);
			threea = square.transform.GetChild(2);
			foura = square.transform.GetChild(3);

			one.position = onea.position;
			two.position = twoa.position;
			three.position = threea.position;
			four.position = foura.position;
		}
		else if(square.tag == "Player"){
			alldots.gameObject.SetActive(false);
		}
		
		
	}
	public void reselect(Transform block){

		if(square != block){
			square.Find("outline").gameObject.SetActive(false);
			square.gameObject.layer = 0;
			square = block;

			square.Find("outline").gameObject.SetActive(true);
			square.gameObject.layer = 2;
		}

		

		

		move.rotation = square.rotation;
		move.localScale = square.localScale;
		move.position = square.position;

		if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko"){
			alldots.gameObject.SetActive(true);
			alldots.rotation = move.rotation;
			
			unterschied =move.position-alldots.position;
			onea = square.transform.GetChild(0);
			twoa = square.transform.GetChild(1);
			threea = square.transform.GetChild(2);
			foura = square.transform.GetChild(3);

			one.position = onea.position;
			two.position = twoa.position;
			three.position = threea.position;
			four.position = foura.position;
			
		}
		else if(square.tag == "Player"){
			alldots.gameObject.SetActive(false);
		}

	}
	/*void MathShit(Transform lol){
		float orthoSize = cam.orthographicSize/5;
		Vector2 pointA = new Vector2(lol.position.x +(orthoSize * Mathf.Sign(lol.position.x-square.position.x)),lol.position.y +(orthoSize * Mathf.Sign(lol.position.y-square.position.y)));
		print(pointA);
		Vector2 pointC = new Vector2((pointA.x+square.position.x)/2,(pointA.y+square.position.y)/2);
		lol.GetComponent<Collider2D>().offset = lol.InverseTransformPoint(new Vector3(pointC.x,pointC.y,0));
	}*/
	void Update () {
		
		if(square.Find("outline")){
			
			square.Find("outline").GetComponent<LineRenderer>().widthMultiplier = cam.orthographicSize/100;
			
			
			//square.Find("outline").GetComponent<LineRenderer>().endWidth = cam.orthographicSize/50;
			//square.Find("outline").GetComponent<LineRenderer>().startWidth = cam.orthographicSize/50;
		}
		if(mode.moveOn && !mode.scaleOn){
			scalililili = true;
			
			move.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f+cam.orthographicSize/(move.localScale.x*4),0.02f+cam.orthographicSize/(move.localScale.y*4));
			movee = true;
		}
		else if(movee && !mode.rotateOn){
			move.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f,0.02f);
			movee = false;
			
			
		}


		if(!GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen){
			if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko"){
			if(!one.GetComponent<Drag>().ok && !two.GetComponent<Drag>().ok && !three.GetComponent<Drag>().ok && !four.GetComponent<Drag>().ok ){
				Scroller.GetComponent<scroll>().canIscroll = true;
			}
			if(mode.scaleOn){
				

				if(scalililili){
					one.position = onea.position;
					two.position = twoa.position;
					three.position = threea.position;
					four.position = foura.position;
					scalililili = false;
					print("lol");
				}



				float offsetX;
				float offsetY;
				one.gameObject.SetActive(true);
				two.gameObject.SetActive(true);
				three.gameObject.SetActive(true);
				four.gameObject.SetActive(true);
				
				one.localScale = new Vector3(cam.orthographicSize,cam.orthographicSize,0);
				two.localScale = new Vector3(cam.orthographicSize,cam.orthographicSize,0);
				three.localScale = new Vector3(cam.orthographicSize,cam.orthographicSize,0);
				four.localScale = new Vector3(cam.orthographicSize,cam.orthographicSize,0);


				
				


				if(mode.scaleOn && !mode.moveOn){
					one.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
					two.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
					three.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
					four.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
					float colliderSize =(one.GetComponent<BoxCollider2D>().size.x/0.02f) * one.localScale.x;

					//offsetX = Mathf.Clamp((colliderSize/2+((one.position.x - two.position.x)/2))/one.localScale.x * 0.02f,0f,0.1f);
					
					//offsetY = Mathf.Clamp((colliderSize/2+((one.position.y - four.position.y)/2))/one.localScale.x * 0.02f,0f,0.1f);
					if(Mathf.Abs(alldots.InverseTransformPoint(one.position).x - alldots.InverseTransformPoint(two.position).x)/0.02<colliderSize){
						if(alldots.InverseTransformPoint(one.position).x < alldots.InverseTransformPoint(two.position).x){
							offsetX = 0.09f;
						}
						else{
							offsetX = -0.09f;
						}
					}
					else{
						offsetX = 0f;
					}
					if(Mathf.Abs(alldots.InverseTransformPoint(one.position).y - alldots.InverseTransformPoint(four.position).y)/0.02<colliderSize){
						if(alldots.InverseTransformPoint(one.position).y < alldots.InverseTransformPoint(four.position).y){
							offsetY = 0.09f;
						}
						else{
							offsetY = -0.09f;
						}
					}
					else{
						offsetY = 0f;
					}
					
				}
				else{
					one.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
					two.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
					three.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
					four.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
					if(alldots.InverseTransformPoint(one.position).y < alldots.InverseTransformPoint(four.position).y){
						offsetY = 0.08f;
					}
					else{
						offsetY = -0.08f;
					}
					if(alldots.InverseTransformPoint(one.position).x < alldots.InverseTransformPoint(two.position).x){
						offsetX = 0.08f;
					}
					else{
						offsetX = -0.08f;
					}
					
				}

				

				//offsetStuff
				//if(one.position.y < four.position.y){
					one.GetComponent<Collider2D>().offset = new Vector2(one.GetComponent<Collider2D>().offset.x,-offsetY); 
					two.GetComponent<Collider2D>().offset = new Vector2(two.GetComponent<Collider2D>().offset.x,-offsetY); 
					three.GetComponent<Collider2D>().offset = new Vector2(one.GetComponent<Collider2D>().offset.x,offsetY); 
					four.GetComponent<Collider2D>().offset = new Vector2(two.GetComponent<Collider2D>().offset.x,offsetY); 
				//}
				/*else{
					one.GetComponent<Collider2D>().offset = new Vector2(one.GetComponent<Collider2D>().offset.x,0.08f); 
					two.GetComponent<Collider2D>().offset = new Vector2(two.GetComponent<Collider2D>().offset.x,0.08f); 
					three.GetComponent<Collider2D>().offset = new Vector2(one.GetComponent<Collider2D>().offset.x,-0.08f); 
					three.GetComponent<Collider2D>().offset = new Vector2(two.GetComponent<Collider2D>().offset.x,-0.08f); 
				}*/
				//if(one.position.x > two.position.x){
					one.GetComponent<Collider2D>().offset = new Vector2(-offsetX,one.GetComponent<Collider2D>().offset.y);
					two.GetComponent<Collider2D>().offset = new Vector2(offsetX,two.GetComponent<Collider2D>().offset.y);
					three.GetComponent<Collider2D>().offset = new Vector2(offsetX,three.GetComponent<Collider2D>().offset.y);
					four.GetComponent<Collider2D>().offset = new Vector2(-offsetX,four.GetComponent<Collider2D>().offset.y);
					
				//}
				/*else{
					one.GetComponent<Collider2D>().offset = new Vector2(-0.08f,one.GetComponent<Collider2D>().offset.y);
					two.GetComponent<Collider2D>().offset = new Vector2(0.08f,two.GetComponent<Collider2D>().offset.y);
					three.GetComponent<Collider2D>().offset = new Vector2(0.08f,three.GetComponent<Collider2D>().offset.y);
					four.GetComponent<Collider2D>().offset = new Vector2(-0.08f,four.GetComponent<Collider2D>().offset.y);
				}*/
			}
			else{
				if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko"){
					one.gameObject.SetActive(false);
					two.gameObject.SetActive(false);
					three.gameObject.SetActive(false);
					four.gameObject.SetActive(false);
				}	
			}
			/*else if(mode.scaleOn && !mode.moveOn){
				one.gameObject.SetActive(true);
				two.gameObject.SetActive(true);
				three.gameObject.SetActive(true);
				four.gameObject.SetActive(true);


				//mathShit
				MathShit(one);
				MathShit(two);
				MathShit(three);
				MathShit(four);
				
			}*/
			
		}
		
		if(Input.touchCount == 1){
			if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko"){
				if(mode.scaleOn){
					
					if(one.GetComponent<Drag>().ok){
					
						oneb = one;
						twob = two;
						threeb = three;
						fourb = four;
						twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					
					}
					else if(two.GetComponent<Drag>().ok){
						oneb = two;
						twob = three;
						threeb = four;
						fourb = one;
						fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					}
					else if(three.GetComponent<Drag>().ok){
						oneb = three;
						twob = four;
						threeb = one;
						fourb = two;
						twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					}
					else if(four.GetComponent<Drag>().ok){
						oneb = four;
						twob = one;
						threeb = two;
						fourb = three;
						fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
						
					}
					

				}
				
				
				
				
				if(move.GetComponent<Drag>().ok && mode.moveOn){
					
					IsScaling = false;
					if(beep){
						unterschied =move.position-alldots.position;
					
					}

					beep = false;
					alldots.position = move.position - unterschied;
					square.position = move.position;
				}
				else if(oneb !=null && threeb !=null && mode.scaleOn && oneb.GetComponent<Drag>().ok){
					

					if(threeb.GetComponent<Drag>().ok){
						threeb.GetComponent<Drag>().ok = false;
					}
					if(twob.GetComponent<Drag>().ok){
						two.GetComponent<Drag>().ok = false;
					}
					if(fourb.GetComponent<Drag>().ok){
						four.GetComponent<Drag>().ok = false;
					}
					IsScaling = true;
					move.localScale = new Vector2(Mathf.Abs(alldots.InverseTransformPoint(oneb.position).x-alldots.InverseTransformPoint(threeb.position).x),Mathf.Abs((alldots.InverseTransformPoint(oneb.position).y-(alldots.InverseTransformPoint(threeb.position).y))))*50;
					move.position = new Vector3((oneb.position.x + threeb.position.x)/2,(oneb.position.y + threeb.position.y)/2,move.position.z);
					
					square.localScale = new Vector2(Mathf.Abs(alldots.InverseTransformPoint(oneb.position).x-alldots.InverseTransformPoint(threeb.position).x),Mathf.Abs((alldots.InverseTransformPoint(oneb.position).y-(alldots.InverseTransformPoint(threeb.position).y))))*50;
					square.position = new Vector3((oneb.position.x + threeb.position.x)/2,(oneb.position.y + threeb.position.y)/2,square.position.z);


					//wenn es früher besser war... mach einfach  antatt tpos hin und lösch das touch zeug
					
					beep = true;
					Scroller.GetComponent<scroll>().canIscroll = false;
					
				}
			
			}
			else if(square.tag == "Player"){
				square.position = move.position;
			}
			if(mode.rotateOn){
				scalililili = true;
				move.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f+cam.orthographicSize/(move.localScale.x*4),0.02f+cam.orthographicSize/(move.localScale.y*4));
				movee = true;
				if(move.GetComponent<rotate>().ok){
					square.rotation = move.rotation;
					if(alldots != null){
						alldots.rotation = move.rotation;
					}
					
				}
					
			}
		}
		
			/*if(Input.GetTouch(0).phase == TouchPhase.Began){
				if(!one.GetComponent<Drag>().ok && !two.GetComponent<Drag>().ok && !three.GetComponent<Drag>().ok && !four.GetComponent<Drag>().ok){
					GameObject.Destroy(this.gameObject);
					print("lololololol");
				}
				
			}*/
			
		}
		
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeThing : MonoBehaviour {

	public Camera cam;
	//public Transform move;
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
	optionStuff optionStuff;

	bool beep =true;
	Vector3 unterschied = new Vector3(0,0,0);
	GameObject Scroller;
	modis mode;
	bool movee;
	bool scalililili = false;
	bool blub = true;

	//bleib beim richtigen
	bool ja = true;
	bool bro = true;
	Vector3 difference = new Vector3();
	Vector2 minusOrNot = new Vector2();
	bool tag_Player = false;
	createGroup createGroup;
	Vector2 localCenter;
	Vector2 Ratio;
	Vector2 colSize;

	void Bounds(){
		print("hi");
		 Quaternion currentRotation = square.rotation;
         square.rotation = Quaternion.Euler(0f,0f,0f);
		 Bounds bounds;
		 if(square.transform.childCount > 5){
			 bounds = new Bounds(square.transform.GetChild(5).position, Vector3.zero);
		 }
         else{
			 bounds = new Bounds(square.position, Vector3.one*3);
		 }
 
         /*foreach(Renderer renderer in square.GetComponentsInChildren<Renderer>())
         {
             bounds.Encapsulate(renderer.bounds);
         }*/
		 for(int i =5; i< square.childCount; i++){
			 if(square.GetChild(i).gameObject.activeSelf)
			 	bounds.Encapsulate(square.GetChild(i).GetComponent<Renderer>().bounds);
		 }
		onea.position = new Vector3(bounds.min.x,bounds.max.y,square.position.z);
		twoa.position = new Vector3(bounds.max.x,bounds.max.y,square.position.z);
		threea.position = new Vector3(bounds.max.x,bounds.min.y,square.position.z);
		foura.position = new Vector3(bounds.min.x,bounds.min.y,square.position.z);
		LineRenderer lr = square.GetComponentInChildren<LineRenderer>();
		lr.SetPosition(0,onea.localPosition);
		lr.SetPosition(1,twoa.localPosition);
		lr.SetPosition(2,threea.localPosition);
		lr.SetPosition(3,foura.localPosition);
        localCenter = square.InverseTransformPoint(bounds.center);
		square.GetComponent<BoxCollider2D>().offset = localCenter;
		colSize = Vector2.Scale(bounds.size, new Vector2(1/square.localScale.x,1/square.localScale.y));
		square.GetComponent<BoxCollider2D>().size = colSize;
		square.GetComponent<rotate>().localCenter = localCenter;
		//print(bounds.size.x + "  " + square.localScale.x + "," + bounds.size.y + "  " + square.localScale.y);
		Ratio = new Vector2((square.localScale.x*0.6f)/bounds.size.x,(square.localScale.y*0.6f)/bounds.size.y);
        // bounds.center = localCenter;
         Debug.Log("The local bounds of this model is " + bounds);
		 square.rotation = currentRotation;
	}
	void Start(){
		createGroup = GameObject.Find("group button").GetComponent<createGroup>();
		cam= GameObject.Find("Main Camera").GetComponent<Camera>();
		Scroller = GameObject.Find("Scroller");
		optionStuff = GameObject.Find("openOptionWindow").GetComponent<optionStuff>();
		mode = GameObject.Find("MODE").GetComponent<modis>();
		
		
		//move.rotation = square.rotation;
		//move.localScale = square.localScale;
		//move.position = square.position;
		square.Find("outline").gameObject.SetActive(true);
		square.GetComponent<BoxCollider2D>().enabled = true;
		if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko" || square.tag == "group"){
			
			tag_Player = false;
			alldots.rotation = square.rotation;
			

			unterschied =square.position-alldots.position;
			onea = square.transform.GetChild(0);
			twoa = square.transform.GetChild(1);
			threea = square.transform.GetChild(2);
			foura = square.transform.GetChild(3);
			if(square.tag == "group"){
				Bounds();
			}
			one.position = onea.position;
			two.position = twoa.position;
			three.position = threea.position;
			four.position = foura.position;
		}
		else if(square.tag == "Player"){
			tag_Player = true;
			alldots.gameObject.SetActive(false);
		}
		

		
	}
	public void addCurrent(){
		if(square.GetComponent<rotate>().enabled && square.GetComponent<rotate>().ok){
			square.GetComponent<rotate>().ok = false;
			Scroller.GetComponent<scroll>().canIscroll2 = true;
			if(square.tag == "group")
				Scroller.GetComponent<undo>().add(square.gameObject, 15, false);
			else
				Scroller.GetComponent<undo>().add(square.gameObject, 3, false);
		}
		if(oneb != null && oneb.GetComponent<Drag>().ok){
			oneb.GetComponent<Drag>().ok = false;
			Scroller.GetComponent<scroll>().canIscroll2 = true;
			Scroller.GetComponent<undo>().add(square.gameObject, 1, false);
			//Scroller.GetComponent<undo>().redo();
		}
		if(square.GetComponent<Drag>().enabled && square.GetComponent<Drag>().ok) {
			square.GetComponent<Drag>().ok = false;
			Scroller.GetComponent<scroll>().canIscroll2 = true;
			Scroller.GetComponent<undo>().add(square.gameObject, 2, false);
			//Scroller.GetComponent<undo>().redo();
		}
		
	}
	public void deselect(){
		addCurrent();
		if(!createGroup.editing){
			createGroup.gameObject.SetActive(false);
		}
		
		if(square.tag == "group"){
			//square.GetComponent<BoxCollider2D>().size = co;
			square.GetComponent<BoxCollider2D>().enabled = false;
		}
			
		else{
			ColliderStuff();
			square.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f,0.02f);
		}
			
		square.GetComponent<Drag>().enabled = false;
		square.GetComponent<rotate>().enabled = false;
		DestroyObject(this.gameObject);
		square.Find("outline").gameObject.SetActive(false);
		square.gameObject.layer = 0;
	}
	void ColliderStuff(){
		int howMany = 0;
		Collider2D[] cols = square.GetComponents<Collider2D>();
		for(int i = 0; i< cols.Length; i++){
			
			if(cols[i].enabled){
				howMany++;
			}
				
		}
		if(howMany > 1){
			square.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
	public void reselect(Transform block){
		addCurrent();

		if(square != block){
			if(square.tag == "group"){
				//square.GetComponent<BoxCollider2D>().size = new Vector2 (0.6f,0.6f);
				square.GetComponent<BoxCollider2D>().enabled = false;
			}
				
			else{
				square.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f,0.02f);
				ColliderStuff();
			}
				
			square.GetComponent<Drag>().enabled = false;
			square.GetComponent<rotate>().enabled = false;
			square.Find("outline").gameObject.SetActive(false);
			square.gameObject.layer = 0;
			if(square.tag == "group"){
				
				square.GetComponent<BoxCollider2D>().enabled = false;
			}
			
			square = block;
			square.Find("outline").gameObject.SetActive(true);
			square.gameObject.layer = 8;
			ja = true;
			beep = true;
			bro = true;
			difference = new Vector3();
			minusOrNot = new Vector2();
			square.GetComponent<BoxCollider2D>().enabled = true;
			
			
		}
		if(square.parent != null){
			createGroup.EditGroup(square);
		}
		else if(square.tag == "group"){
			createGroup.select();
		}
		else{
			createGroup.darkThingOff();
			createGroup.state = 0;
			createGroup.textMesh.text = "create group";
		}

		

		

		

		if(square.tag == "goal" || square.tag == "water" || square.tag == "obstacle" || square.tag == "ground" || square.tag == "deko" || square.tag == "group"){
			tag_Player = false;
			alldots.gameObject.SetActive(true);
			alldots.rotation = square.rotation;
			
			unterschied =square.position-alldots.position;
			onea = square.transform.GetChild(0);
			twoa = square.transform.GetChild(1);
			threea = square.transform.GetChild(2);
			foura = square.transform.GetChild(3);
			if(square.tag == "group"){
						
				square.GetComponent<BoxCollider2D>().enabled = true;
				Bounds();
			}
			one.position = onea.position;
			two.position = twoa.position;
			three.position = threea.position;
			four.position = foura.position;
			
			
		}
		else if(square.tag == "Player"){
			tag_Player = true;
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
			
		square.Find("outline").GetComponent<LineRenderer>().widthMultiplier = cam.orthographicSize/100;
			
			
			//square.Find("outline").GetComponent<LineRenderer>().endWidth = cam.orthographicSize/50;
			//square.Find("outline").GetComponent<LineRenderer>().startWidth = cam.orthographicSize/50;
		
		if((mode.moveOn && !mode.scaleOn) || mode.rotateOn){
			scalililili = true;
			if(square.tag == "group")
				square.GetComponent<BoxCollider2D>().size = new Vector2 (colSize.x+cam.orthographicSize/Mathf.Abs(square.localScale.x*4),colSize.y+cam.orthographicSize/Mathf.Abs(square.localScale.y*4));
			else
				square.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f+cam.orthographicSize/Mathf.Abs(square.lossyScale.x*4),0.02f+cam.orthographicSize/Mathf.Abs(square.lossyScale.y*4));
				/*if(square.parent != null){
					square.GetComponent<BoxCollider2D>().size = new Vector2 (square.GetComponent<BoxCollider2D>().size.x/Mathf.Abs(square.parent.localScale.x),square.GetComponent<BoxCollider2D>().size.y/Mathf.Abs(square.parent.localScale.y));
				}*/
			movee = true;
			
		}
		else if(movee && !mode.rotateOn){
			if(square.tag == "group")
				square.GetComponent<BoxCollider2D>().size = colSize;
			else
				square.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f,0.02f);
			movee = false;
			
			
		}
		if(mode.moveOn)
			square.GetComponent<Drag>().enabled = true;
		else
			square.GetComponent<Drag>().enabled = false;
		

		if(!Scroller.GetComponent<isSomethingOpen>().SomethingOpen){
			if(!tag_Player){
			if(!one.GetComponent<Drag>().ok && !two.GetComponent<Drag>().ok && !three.GetComponent<Drag>().ok && !four.GetComponent<Drag>().ok ){
				Scroller.GetComponent<scroll>().canIscroll = true;
			}
			if(mode.scaleOn){
				if(blub){
					one.position = onea.position;
					two.position = twoa.position;
					three.position = threea.position;
					four.position = foura.position;
					blub = false;
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


				
				


				if(!mode.moveOn){
					
					if(ja){
						one.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
						two.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
						three.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
						four.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);
						
						ja = false;
					}
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
					if(!ja){
						one.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
						two.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
						three.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
						four.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
						ja = true;
					}
					
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
				blub = true;
				one.gameObject.SetActive(false);
				two.gameObject.SetActive(false);
				three.gameObject.SetActive(false);
				four.gameObject.SetActive(false);
					
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
			if(!tag_Player){
				if(mode.scaleOn){
					
					if(one.GetComponent<Drag>().ok){
						minusOrNot.x = -1;
						minusOrNot.y = 1;
						oneb = one;
						twob = two;
						threeb = three;
						fourb = four;
						//twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						//fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					
					}
					else if(two.GetComponent<Drag>().ok){
						minusOrNot.x = 1;
						minusOrNot.y = 1;
						oneb = two;
						twob = three;
						threeb = four;
						fourb = one;
						//fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						//twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					}
					else if(three.GetComponent<Drag>().ok){
						minusOrNot.x = 1;
						minusOrNot.y = -1;
						oneb = three;
						twob = four;
						threeb = one;
						fourb = two;
						//twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						//fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
					}
					else if(four.GetComponent<Drag>().ok){
						minusOrNot.x = -1;
						minusOrNot.y = -1;
						oneb = four;
						twob = one;
						threeb = two;
						fourb = three;
						//fourb.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(threeb.position).x, alldots.InverseTransformPoint(oneb.position).y));
						//twob.position= alldots.TransformPoint(new Vector2(alldots.InverseTransformPoint(oneb.position).x, alldots.InverseTransformPoint(threeb.position).y));
						
					}
					

				}
				
				
				
				
				if(square.GetComponent<Drag>().ok && mode.moveOn){
					Touch touch = Input.GetTouch(0);

					Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
					if(bro){
						difference = new Vector3(square.position.x-touchPos.x,square.position.y-touchPos.y,-10);
						isSomethingOpen.modified = true;
						Scroller.GetComponent<scroll>().canIscroll2 = false;
						Scroller.GetComponent<undo>().add(square.gameObject, 2, true);
						bro = false;
					}
					Vector3 movePos = new Vector3(touchPos.x,touchPos.y, square.position.z)+new Vector3(difference.x,difference.y,0);
					if(beep){
						unterschied = movePos-alldots.position;
						beep = false;
					
					}
					

					optionStuff.changePosition();
					alldots.position = movePos-unterschied;
					square.position = movePos;
					if(touch.phase == TouchPhase.Ended){
						square.GetComponent<Drag>().ok = false;
						Scroller.GetComponent<scroll>().canIscroll2 = true;
						Scroller.GetComponent<undo>().add(square.gameObject, 2, false);
						bro = true;
					}
				}
				else if(oneb !=null && threeb !=null && mode.scaleOn && oneb.GetComponent<Drag>().ok){
					

					Touch touch = Input.GetTouch(0);

					Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
					
					if(bro){
						difference = new Vector3(oneb.position.x-touchPos.x,oneb.position.y-touchPos.y,-10);
						isSomethingOpen.modified = true;
						Scroller.GetComponent<scroll>().canIscroll2 = false;
						Scroller.GetComponent<undo>().add(square.gameObject, 1, true);
						bro = false;
						
						
					}
					Vector3 onebPos = new Vector3(touchPos.x,touchPos.y,square.position.z)+new Vector3(difference.x,difference.y,0);
					

					Vector2 onebInverse;
					Vector2 threebInverse;
					if(square.parent != null){
						//Hey Ben aus der Zukunft, Ich habe kp wie ich das gemacht habe... wenn du es auch nur falsch anguckst wird es nichtmehr funktionieren.
						onebInverse = Quaternion.Inverse(square.localRotation)*(square.parent.InverseTransformPoint(onebPos)-square.localPosition);
						threebInverse = Quaternion.Inverse(square.localRotation)*(square.parent.InverseTransformPoint(threeb.position)-square.localPosition);
					}
					else{
						onebInverse = square.InverseTransformDirection(onebPos);
						threebInverse = square.InverseTransformDirection(threeb.position);
					}
					Vector2 lol;
					if(square.tag == "group"){
						//print(onebPos +" "+threeb.position);
						lol = lol = new Vector2((onebInverse.x-threebInverse.x)*minusOrNot.x,(onebInverse.y-threebInverse.y)*minusOrNot.y)/0.6f;
						lol= Vector2.Scale(lol,Ratio);
						//Vector3 deltaPos = square.TransformPoint(localCenter);
						print(square.TransformPoint(localCenter));
						square.localScale = lol;
						square.position -= square.TransformPoint(localCenter) - (onebPos+threeb.position)*0.5f;
						//square.position -= square.TransformPoint(localCenter) -  new Vector3((onebPos.x + threeb.position.x)/2,(onebPos.y + threeb.position.y)/2,0);
					}
					else{
						lol = lol = new Vector2((onebInverse.x-threebInverse.x)*minusOrNot.x,(onebInverse.y-threebInverse.y)*minusOrNot.y)*50;
						square.localScale = lol;
						square.position = (onebPos+threeb.position)*0.5f;
					}
					

					/*if(square.parent != null){
						Vector2 Ps = new Vector2(1/square.parent.localScale.x,1/square.parent.localScale.y);
						lol = Vector2.Scale(Ps,Quaternion.Inverse(square.parent.rotation) *lol);
					}*/
					
					
					

					
					
					
					
					optionStuff.changePosition();
					optionStuff.changeScale();
					one.position = onea.position;
					two.position = twoa.position; 
					three.position = threea.position;
					four.position = foura.position;
					
					beep = true;
					if(touch.phase == TouchPhase.Ended){
						one.GetComponent<Drag>().ok = false;
						two.GetComponent<Drag>().ok = false;
						three.GetComponent<Drag>().ok = false;
						four.GetComponent<Drag>().ok = false;

						Scroller.GetComponent<undo>().add(square.gameObject, 1, false);
						bro = true;
						Scroller.GetComponent<scroll>().canIscroll2 = true;
					}
					
				}
			
			}
			else if(tag_Player){
				//square.position = move.position;
				if(square.GetComponent<Drag>().ok && mode.moveOn){
					Touch touch = Input.GetTouch(0);

					Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10));
					Vector2 touchPosWorld2D = new Vector2(touchPos.x,touchPos.y);
					if(bro){
						difference = new Vector3(square.position.x-touchPos.x,square.position.y-touchPos.y,-10);
						isSomethingOpen.modified = true;
						print("yrah");
						Scroller.GetComponent<scroll>().canIscroll2 = false;
						Scroller.GetComponent<undo>().add(square.gameObject, 2, true);
						bro = false;
					}
					Vector3 movePos = new Vector3(touchPos.x,touchPos.y, square.position.z)+new Vector3(difference.x,difference.y,0);
					//if(beep){
						//unterschied =movePos-alldots.position;
					
					//}
					

					beep = false;
					square.position = movePos;
					optionStuff.changePosition();
					if(touch.phase == TouchPhase.Ended){
						square.GetComponent<Drag>().ok = false;
						Scroller.GetComponent<undo>().add(square.gameObject, 2, false);
						bro = true;
						Scroller.GetComponent<scroll>().canIscroll2 = true;
					}
				}
			}
			if(mode.rotateOn){
				square.GetComponent<rotate>().enabled = true;
				scalililili = true;
				//move.GetComponent<BoxCollider2D>().size = new Vector2 (0.02f+cam.orthographicSize/(move.localScale.x*4),0.02f+cam.orthographicSize/(move.localScale.y*4));
				movee = true;
				if(square.GetComponent<rotate>().ok){
					square.rotation = square.rotation;
					if(alldots != null){
						alldots.rotation = square.rotation;
					}
					
				}
					
			}
			else{
				square.GetComponent<rotate>().enabled = false;
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

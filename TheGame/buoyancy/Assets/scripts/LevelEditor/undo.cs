using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undo : MonoBehaviour {
	//public Stuff[] history;

	public int groundL = 0;
	public int obstacleL = 0;
	public int goalL = 0;
	public int waterL = 0;
	public int dekoL = 0;
	public int playerL = 0;
	public List<GameObject> allThings = new List<GameObject>();
	
	//public List<Stuff> history = new List<Stuff>();
	public List<Infos> history = new List<Infos>();
	public GameObject undoB;
	public GameObject redoB;

	//things
	public GameObject ground;
	public GameObject water;
	public GameObject deko;
	public GameObject obstacle;
	public GameObject player;
	public GameObject goal;
	public Sprite[] shapes;
	public open menu;
	bool reddo = true;
	int HisPos = 0;
	public FarbenLager cam;
	public openColorStuff changeBackground;

	public void undoo () {
		if(!reddo && HisPos != 1){
			if(history[HisPos-1].whatToDo == 0){
				HisPos++;
				print("lololololololololololol");
			}
			
			
		}
		if(history[HisPos-1].whatToDo != 0){
			if(HisPos-1 >1){
				if(!history[HisPos-1].ae && history[HisPos-2].ae){
					HisPos--;
				}
			}
			else if(!history[HisPos-1].ae){
				HisPos--;
			}
			
		}
		if(HisPos >0){
			HisPos--;
			if(HisPos>0){
				blub(true, HisPos);
			}
			else{
				blub(true, 0);
			}
			
		}
		else{
			blub(true, 0);
		}
		if(HisPos == 0){
			undoB.SetActive(false);
		}

		redoB.SetActive(true);
		reddo = true;
		

		
	}
	/*void Update(){
		print(HisPos + "pos");
		print(history.Count + "count");
		print(reddo + "reddo");
	}*/
	public void redo () {
		undoB.SetActive(true);
		if(reddo && history[HisPos].whatToDo == 0){
			blub(false, HisPos);
			HisPos++;
			if(HisPos >= history.Count-1){
				redoB.SetActive(false);
			}
			return;
		}
		if(history.Count > HisPos+1){
			if(history[HisPos+1].whatToDo != 0 && history[HisPos+1].ae && !history[HisPos+2].ae){
				HisPos++;
			}
		}

		reddo = false;
		print("hmmm");
		
		HisPos++;
		if(HisPos >= history.Count-1){
			redoB.SetActive(false);
		}
		undoB.SetActive(true);
		/*if(history[HisPos-1].delete){
			print("lollo");
			if(history.Count > HisPos){
				if(history[HisPos-1].number != history[HisPos].number||history[HisPos-1].tag != history[HisPos].tag){
					print("9_yay");
					blub(false, HisPos-1);
					undoB.SetActive(true);
					reddo = true;
					return;
				}
			}
			else{
				print("10_yay");
				blub(false, HisPos-1);
				undoB.SetActive(true);
				reddo = true;
				return;
			}
			
		}*/
		blub(false, HisPos);
		
		
		
	}
	
	// Update is called once per frame
	public void add (GameObject thing, int WhatToDoo, bool ae) {
		redoB.SetActive(false);
		reddo = true;
		for(int j = history.Count-1; j>HisPos-1; j--){
			history.RemoveAt(j);
		}
		
		HisPos++;
		float[] loli = null;
		switch(WhatToDoo){
			case 0:
				if(thing.tag == "water"){
					loli = new float[13];
					loli[0] = thing.transform.position.x;
					loli[1] = thing.transform.position.y;
					loli[2] = thing.transform.position.z;
					loli[3] = thing.transform.localScale.x;
					loli[4] = thing.transform.localScale.y;
					loli[5] = thing.transform.rotation.eulerAngles.z;
					loli[6] = thing.GetComponent<SpriteRenderer>().color.r;
					loli[7] = thing.GetComponent<SpriteRenderer>().color.g;
					loli[8] = thing.GetComponent<SpriteRenderer>().color.b;
					loli[9] = thing.GetComponent<SpriteRenderer>().color.a;
					loli[10] = thing.GetComponent<Draggable>().Shape;
					loli[11] = thing.GetComponent<water>().waterForceX;
					loli[12] = thing.GetComponent<water>().waterForceY;
				}
				else{
					loli = new float[11];
					loli[0] = thing.transform.position.x;
					loli[1] = thing.transform.position.y;
					loli[2] = thing.transform.position.z;
					loli[3] = thing.transform.localScale.x;
					loli[4] = thing.transform.localScale.y;
					loli[5] = thing.transform.rotation.eulerAngles.z;
					loli[6] = thing.GetComponent<SpriteRenderer>().color.r;
					loli[7] = thing.GetComponent<SpriteRenderer>().color.g;
					loli[8] = thing.GetComponent<SpriteRenderer>().color.b;
					loli[9] = thing.GetComponent<SpriteRenderer>().color.a;
					loli[10] = thing.GetComponent<Draggable>().Shape;
				}
				break;
			case 1:
				loli = new float[5];
				loli[0] = thing.transform.position.x;
				loli[1] = thing.transform.position.y;
				loli[2] = thing.transform.position.z;
				loli[3] = thing.transform.localScale.x;
				loli[4] = thing.transform.localScale.y;
				break;
			case 2:
				loli = new float[3];
				loli[0] = thing.transform.position.x;
				loli[1] = thing.transform.position.y;
				loli[2] = thing.transform.position.z;
				break;
			case 3:
				loli = new float[1];
				loli[0] = thing.transform.rotation.eulerAngles.z;
				break;	
			case 4:
				loli = new float[4];
				loli[0] = thing.GetComponent<SpriteRenderer>().color.r;
				loli[1] = thing.GetComponent<SpriteRenderer>().color.g;
				loli[2] = thing.GetComponent<SpriteRenderer>().color.b;
				loli[3] = thing.GetComponent<SpriteRenderer>().color.a;
				break;	
			case 5:
				loli = new float[4];
				loli[0] = cam.GetComponent<FarbenLager>().bg1.r;
				loli[1] = cam.GetComponent<FarbenLager>().bg1.g;
				loli[2] = cam.GetComponent<FarbenLager>().bg1.b;
				break;
			case 6:
				loli = new float[4];
				loli[0] = cam.GetComponent<FarbenLager>().bg2.r;
				loli[1] = cam.GetComponent<FarbenLager>().bg2.g;
				loli[2] = cam.GetComponent<FarbenLager>().bg2.b;
				break;	
			case 7:
				print("hallo");
				loli = new float[5];
				loli[0] = thing.GetComponent<water>().waterForceX;
				loli[1] = thing.GetComponent<SpriteRenderer>().color.r;
				loli[2] = thing.GetComponent<SpriteRenderer>().color.g;
				loli[3] = thing.GetComponent<SpriteRenderer>().color.b;
				loli[4] = thing.GetComponent<SpriteRenderer>().color.a;
				break;
			case 8:
				print("hallo2");
				loli = new float[5];

				loli[0] = thing.GetComponent<water>().waterForceY;
				loli[1] = thing.GetComponent<SpriteRenderer>().color.r;
				loli[2] = thing.GetComponent<SpriteRenderer>().color.g;
				loli[3] = thing.GetComponent<SpriteRenderer>().color.b;
				loli[4] = thing.GetComponent<SpriteRenderer>().color.a;
				break;
			case 9:
				loli = new float[1];

				loli[0] = thing.GetComponent<Draggable>().Shape;
				break;


		}
		if(WhatToDoo != 5 && WhatToDoo != 6){
			history.Add(new Infos(thing.tag, thing.GetComponent<Draggable>().ObjectLPos,WhatToDoo, loli, ae));
		}
		else{
			history.Add(new Infos("", 0,WhatToDoo, loli, ae));
		}
		
		/*if(thing.tag == "water"){
			history.Add(new Stuff(thing.GetComponent<Draggable>().ObjectLPos, thing.transform.position,thing.transform.localScale,thing.transform.rotation,thing.GetComponent<SpriteRenderer>().color, delete, thing.tag,
			new Vector2(thing.GetComponent<water>().waterForceX,thing.GetComponent<water>().waterForceY), ae));
		}
		else{
			history.Add(new Stuff(thing.GetComponent<Draggable>().ObjectLPos, thing.transform.position,thing.transform.localScale,thing.transform.rotation,thing.GetComponent<SpriteRenderer>().color, delete,thing.tag, new Vector2(0,0),ae));
		}*/
		//int i = history.Count-1;
		//print(history[i].thing+""+history[i].pos+""+ history[i].scale+""+ history[i].rotation+""+ history[i].color);
		undoB.SetActive(true);
		
	}
	void blub(bool unddo, int Pos){

		//GameObject thing = GetObject(history[Pos].tag, history[Pos].number, Pos);
		print("hi");

		if(history[Pos].tag != ""){
			GameObject thing = allThings[history[Pos].number];
			
			
			

			if(history[Pos].whatToDo == 0 && thing != null){
				if(GameObject.Find("sizeStuff(Clone)")){
					sizeThing sizeStuff = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
					if(sizeStuff.square.gameObject == thing){
						Destroy(sizeStuff.gameObject);
						menu.closeTheMenu();
					}
				}
				Destroy(thing);
				//history.RemoveAt(HisPos);
				
			}
			
			else if(thing == null && history[Pos].whatToDo == 0){
				GameObject thingy = null;
				
				Infos lol = history[Pos];
				Vector3 pos = new Vector3(lol.größen[0],lol.größen[1],lol.größen[2]);
				Quaternion roti = Quaternion.Euler(0,0, lol.größen[5]);
				Vector3 scali = new Vector3(lol.größen[3],lol.größen[4],0);
				Color col = new Color(lol.größen[6],lol.größen[7],lol.größen[8],lol.größen[9]);
				switch(history[Pos].tag){
					
					case "ground":
						thingy = GameObject.Instantiate(ground,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<SpriteRenderer>().color = col;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						//groundL[history[Pos].number] = thingy;
						break;

					case "water":
						thingy = GameObject.Instantiate(water,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<SpriteRenderer>().color = col;
						thingy.GetComponent<water>().waterForceY = lol.größen[12];
						thingy.GetComponent<water>().waterForceX = lol.größen[11];
						thingy.GetComponent<water>().colorChanged = true;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						//waterL[history[Pos].number] = thingy;
						
						break;

					case "obstacle":
						thingy = GameObject.Instantiate(obstacle,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						thingy.GetComponent<SpriteRenderer>().color = col;
						//obstacleL[history[Pos].number] = thingy;
						break;

					case "goal":
						thingy = GameObject.Instantiate(goal,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						thingy.GetComponent<SpriteRenderer>().color = col;
						//goalL[history[Pos].number] = thingy;
						break;
					
					case "deko":
						thingy = GameObject.Instantiate(deko,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						thingy.GetComponent<SpriteRenderer>().color = col;
						//dekoL[history[Pos].number] = thingy;
							/*if(info.Length >5){
								thing.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(info[5]);
							}
							else{
								thing.GetComponent<SpriteRenderer>().sortingOrder = GameObject.FindGameObjectsWithTag("deko").Length-1;
							}*/
						
						break;
					
					case "Player":
						thingy = GameObject.Instantiate(player,pos,roti);
						thingy.transform.localScale = scali;
						thingy.GetComponent<SpriteRenderer>().color = col;
						//playerL[history[Pos].number] = thingy;
						thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
						break;
					default:
						print("lol");
					break;
				}
				int shape = (int)lol.größen[10];
				switch(shape){
					case 0:
						
						thingy.GetComponent<BoxCollider2D>().enabled = true;
						break;
					case 1:
						thingy.GetComponent<CircleCollider2D>().enabled = true;
						break;
					case 2:
						thingy.GetComponents<PolygonCollider2D>()[1].enabled = true;
						break;
					case 3:
						thingy.GetComponents<PolygonCollider2D>()[0].enabled = true;
						break;
				}
				thingy.GetComponent<SpriteRenderer>().sprite = shapes[shape];
				allThings[history[Pos].number] = thingy;
				//history[HisPos]=(new Stuff(thingy, lol.pos,lol.scale,lol.rotation,lol.color, lol.delete, lol.tag,lol.WaterPower));

				
			}
			else{
				int WTD =  history[Pos].whatToDo;
				float[] lol = history[Pos].größen;
				switch(WTD){
					case 1:
						thing.transform.position = new Vector3(lol[0],lol[1],lol[2]);
						thing.transform.localScale = new Vector3(lol[3],lol[4],0);
						if(GameObject.Find("sizeStuff(Clone)")){
							GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(thing.transform);
						}
						break;
					case 2:
						thing.transform.position = new Vector3(lol[0],lol[1],lol[2]);
						if(GameObject.Find("sizeStuff(Clone)")){
							GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(thing.transform);
						}
						break;	
					case 3:
						thing.transform.rotation = Quaternion.Euler(0,0, lol[0]);
						if(GameObject.Find("sizeStuff(Clone)")){
							GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(thing.transform);
						}
						break;
					case 4:
						thing.GetComponent<SpriteRenderer>().color = new Color(lol[0],lol[1],lol[2],lol[3]);
						break;	
					case 7:
						thing.GetComponent<water>().waterForceX = lol[0];
						thing.GetComponent<SpriteRenderer>().color = new Color(lol[1],lol[2],lol[3],lol[4]);
						break;	
					case 8:
						thing.GetComponent<water>().waterForceY = lol[0];
						thing.GetComponent<SpriteRenderer>().color = new Color(lol[1],lol[2],lol[3],lol[4]);
						break;
					case 9:
						int shape = (int)lol[0];
						switch(shape){
							case 0:
								
								thing.GetComponent<BoxCollider2D>().enabled = true;
								break;
							case 1:
								thing.GetComponent<CircleCollider2D>().enabled = true;
								break;
							case 2:
								thing.GetComponents<PolygonCollider2D>()[1].enabled = true;
								break;
							case 3:
								thing.GetComponents<PolygonCollider2D>()[0].enabled = true;
								break;
							}
							thing.GetComponent<SpriteRenderer>().sprite = shapes[shape];
							break;
				}
				/*thing.transform.position = lol.pos;
				thing.transform.localScale = lol.scale;
				thing.transform.rotation = lol.rotation;
				thing.GetComponent<SpriteRenderer>().color = lol.color;
				if(thing.tag == "water"){
					thing.GetComponent<water>().waterForceX = lol.WaterPower.x;
					thing.GetComponent<water>().waterForceY = lol.WaterPower.y;
				}
				if(GameObject.Find("sizeStuff(Clone)")){
					sizeThing sizeStuff = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
					if(sizeStuff.square.gameObject == thing){
						sizeStuff.reselect(thing.transform);
					}
				}*/
			}
		}
		else{
			float[] lol = history[Pos].größen;
			Color col = new Color(lol[0],lol[1],lol[2],1);
			if(history[Pos].whatToDo == 5){
				cam.bg1 = col;
				print("undo Zeugs");
				cam.GetComponent<Camera>().backgroundColor = col;
			}
			else{
				cam.bg2 = col;
			}
			changeBackground.changebgColor();
		}
		
	}
	/*GameObject GetObject(string tag, int nummer, int pos){
		GameObject thing = null;

		switch(history[pos].tag){
			case "ground":
				thing = groundL[nummer];
				break;
			case "water":
				thing = waterL[nummer];
				break;
			case "deko":
				thing = dekoL[nummer];
				break;
			case "goal":
				thing = goalL[nummer];
				break;
			case "obstacle":
				thing = obstacleL[nummer];
				break;	
			case "Player":
				thing = playerL[nummer];
				break;
			default:
				print("lol");
				break;					

		}

		return(thing);
	}*/
}
/* 
[System.Serializable]
public class Stuff{
	public int number;
	public Vector3 pos;
	public Vector3 scale;
	public Quaternion rotation;
	public Color color;
	public bool delete;
	public Vector2 WaterPower;
	public string tag;
	public bool ae;

	public Stuff(int numbery, Vector3 posy , Vector3 scaley, Quaternion rotationy, Color colory, bool deletey, string taggy,Vector2 WaterPowery, bool aey ){
		number = numbery;
		pos = posy;
		scale = scaley;
		rotation = rotationy;
		color = colory;
		delete = deletey;
		WaterPower = WaterPowery;
		tag = taggy;
		ae = aey;
	}

}*/
[System.Serializable]
public class Infos{
	public string tag;
	public int number;
	public int whatToDo;
	public float[] größen;
	public bool ae;

	public Infos(string tagy, int objy, int whatToDoy, float[] größis, bool aey){
		tag = tagy;
		number = objy;
		whatToDo = whatToDoy;
		größen = größis;
		ae = aey;
	}
}

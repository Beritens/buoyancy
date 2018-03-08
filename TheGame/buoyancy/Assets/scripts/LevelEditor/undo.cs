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
	public int HisPos = 0;
	public FarbenLager cam;
	public openColorStuff changeBackground;
	public optionStuff optionStuff;
	public createGroup createGroup;
	public sizeThing sizeThing;

	public void undoo () {
		if(sizeThing != null){
			sizeThing.addCurrent();
		}
		else if(sizeThing == null && GameObject.Find("sizeStuff(Clone)")){
			sizeThing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
			sizeThing.addCurrent();
		}
		
		int howMuch = 0;
		if(!reddo){
			howMuch++;
		}
		if(history[HisPos+howMuch-1].whatToDo == 0 || history[HisPos+howMuch-1].whatToDo == 14){
			HisPos++;
		}
		reddo = true;
		howMuch -= 2;
		if(HisPos+howMuch == 0){
			undoB.SetActive(false);
		}
		blub(HisPos+howMuch);
		

		redoB.SetActive(true);
		
		

		
	}
	public void redo () {
		if(sizeThing != null){
			sizeThing.addCurrent();
		}
		else if(sizeThing == null && GameObject.Find("sizeStuff(Clone)")){
			sizeThing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
			sizeThing.addCurrent();
			
		}
		int howMuch = 0;
		if(reddo){
			howMuch--;
		}
		if(history[HisPos+howMuch+1].whatToDo == 0 || history[HisPos+howMuch+1].whatToDo == 14){
			howMuch--;
		}

		reddo = false;
		
		howMuch += 2;
		if(HisPos+howMuch >= history.Count-1){
			redoB.SetActive(false);
		}
		undoB.SetActive(true);

		blub(HisPos+howMuch);
		
		
		
	}
	public void add (GameObject thing, int WhatToDoo, bool ae) {
		redoB.SetActive(false);
		if(!reddo){
			HisPos++;
		}
			
		reddo = true;
		for(int j = history.Count-1; j>HisPos-1; j--){
			if(history[j].whatToDo == 0 && !allThings[history[j].number].activeSelf){
				Destroy(allThings[history[j].number]);
			}
			history.RemoveAt(j);
		}
		HisPos++;
		
		
		float[] loli = null;
		switch(WhatToDoo){
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
				loli = new float[5];
				loli[0] = thing.GetComponent<water>().waterForceX;
				loli[1] = thing.GetComponent<SpriteRenderer>().color.r;
				loli[2] = thing.GetComponent<SpriteRenderer>().color.g;
				loli[3] = thing.GetComponent<SpriteRenderer>().color.b;
				loli[4] = thing.GetComponent<SpriteRenderer>().color.a;
				break;
			case 8:
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
			case 10:
				loli = new float[2];
				loli[0] = thing.transform.localScale.x;
				loli[1] = thing.transform.localScale.y;
				break;
			case 11:
				loli = new float[1];
				loli[0] = thing.GetComponent<Draggable>().bounciness;
				break;	
			case 12:
				loli = new float[1];
				if(thing.GetComponent<Draggable>().falling){
					loli[0] = 1;
				}
				else{
					loli[0] = 0;
				}
				break;	
			case 13:
				loli = new float[1];
				loli[0] = thing.GetComponent<Draggable>().mass;
				break;
			case 14:
				loli = new float[1];
				loli[0] = thing.transform.parent.GetComponent<Draggable>().ObjectLPos;
				break;
			case 15:
				loli = new float[3];
				loli[0] = thing.transform.rotation.eulerAngles.z;
				loli[1] = thing.transform.position.x;
				loli[2] = thing.transform.position.y;
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
	void blub(int Pos){
		//GameObject thing = GetObject(history[Pos].tag, history[Pos].number, Pos);

		if(history[Pos].tag != ""){
			GameObject thing = allThings[history[Pos].number];
			
			int WTD =  history[Pos].whatToDo;
			float[] lol = history[Pos].größen;
			sizeThing = null;
			bool change = false;
			if(GameObject.Find("sizeStuff(Clone)")){
				sizeThing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
				if(history[Pos].number != sizeThing.square.GetComponent<Draggable>().ObjectLPos){
					change = true;
				}
			}
			switch(WTD){
				case 0:
					if(thing.activeSelf){
						thing.layer = 0;
						//thing.transform.Find("outline").gameObject.SetActive(false);
						thing.SetActive(false);
						if(sizeThing != null && !change){
							menu.closeTheMenu();
							sizeThing.deselect();
						}
						
						change = false;
					}
					else
						thing.SetActive(true);
					break;
				case 1:
				print("lol");
					thing.transform.position = new Vector3(lol[0],lol[1],lol[2]);
					thing.transform.localScale = new Vector3(lol[3],lol[4],0);
					if(sizeThing != null && !change){
						sizeThing.reselect(thing.transform);
						optionStuff.changePosition();
						optionStuff.changeScale();
						
					}
					break;
				case 2:
					thing.transform.position = new Vector3(lol[0],lol[1],lol[2]);
					if(sizeThing != null && !change){
						sizeThing.reselect(thing.transform);
						optionStuff.changePosition();
					}
					break;	
				case 3:
					thing.transform.rotation = Quaternion.Euler(0,0, lol[0]);
					if(sizeThing != null && !change){
						optionStuff.changeRotation();
						sizeThing.reselect(thing.transform);
					}
					break;
				case 4:
					Color coloryy = new Color(lol[0],lol[1],lol[2],lol[3]);
					thing.GetComponent<SpriteRenderer>().color = coloryy;
					if(!change){
						optionStuff.changeColor(coloryy);
					}
					break;	
				case 7:
					thing.GetComponent<water>().waterForceX = lol[0];
					Color colory = new Color(lol[1],lol[2],lol[3],lol[4]);
					thing.GetComponent<SpriteRenderer>().color = colory;
					if(!change){
						optionStuff.changeWaterX();
						optionStuff.changeColor(colory);
					}
					break;	
				case 8:
					thing.GetComponent<water>().waterForceY = lol[0];
					Color color = new Color(lol[1],lol[2],lol[3],lol[4]);
					thing.GetComponent<SpriteRenderer>().color = color;
					if(!change){
						optionStuff.changeWaterY();
						optionStuff.changeColor(color);
					}
					break;
				case 9:
					if(thing.tag == "Player"){
						thing.GetComponent<CircleCollider2D>().enabled = false;
					}
					else{
						thing.GetComponents<PolygonCollider2D>()[2].enabled = false;
					}
					thing.GetComponents<PolygonCollider2D>()[1].enabled = false;
					thing.GetComponents<PolygonCollider2D>()[0].enabled = false;
					if(sizeThing == null || change){
						thing.GetComponent<BoxCollider2D>().enabled = false;
					}

					int shape = (int)lol[0];
					switch(shape){
						case 0:
							
							thing.GetComponent<BoxCollider2D>().enabled = true;
							break;
						case 1:
							if(thing.tag == "Player"){
								thing.GetComponent<CircleCollider2D>().enabled = true;
							}
							else{
								thing.GetComponents<PolygonCollider2D>()[2].enabled = true;
							}
							
							break;
						case 2:
							thing.GetComponents<PolygonCollider2D>()[1].enabled = true;
							break;
						case 3:
							thing.GetComponents<PolygonCollider2D>()[0].enabled = true;
							break;
						}
						thing.GetComponent<SpriteRenderer>().sprite = shapes[shape];
						
						if(!change){
							optionStuff.changeTheShape();
						}
						break;
				case 10:
					thing.transform.localScale = new Vector3(lol[3],lol[4],0);
					if(sizeThing != null && !change){
						optionStuff.changeScale();
						sizeThing.reselect(thing.transform);
					}
					break;
				case 11:
					thing.GetComponent<Draggable>().bounciness = lol[0];
					if(!change){
						optionStuff.changeBounciness();
					}	
					break;
				case 12:
					thing.GetComponent<Draggable>().falling = lol[0] == 1;
					if(!change){
						optionStuff.changeFalling();
					}	
					break;
				case 13:
					thing.GetComponent<Draggable>().mass = lol[0];
					if(!change){
						optionStuff.changeMass();
					}	
					break;
				case 14:
					if(thing.transform.parent == allThings[(int)lol[0]].transform){
						allThings[(int)lol[0]].SetActive(false);
						thing.transform.parent = null;
						if(createGroup.groupy == allThings[(int)lol[0]].transform && createGroup.editing){
							createGroup.darkThingOff();
							createGroup.editing = false;
						}
					}
					else{
						allThings[(int)lol[0]].SetActive(true);
						thing.transform.parent= allThings[(int)lol[0]].transform;
						if(sizeThing!= null && !change){
							//change = false;
							sizeThing.reselect(thing.transform);
						}
						
					}
					break;
				case 15:
					thing.transform.rotation = Quaternion.Euler(0,0, lol[0]);
					thing.transform.position = new Vector3(lol[1],lol[2],thing.transform.position.z);
					if(sizeThing != null && !change){
						sizeThing.reselect(thing.transform);
						optionStuff.changePosition();
					}
					break;	
			}
			if(change){
				sizeThing.reselect(thing.transform);
				optionStuff.select(thing);
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
			//changeBackground.changebgColor();
		}
		HisPos = Pos;
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

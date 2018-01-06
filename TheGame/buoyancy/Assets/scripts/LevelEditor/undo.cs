using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undo : MonoBehaviour {
	//public Stuff[] history;

	public List<GameObject> groundL = new List<GameObject>();
	public List<GameObject> obstacleL = new List<GameObject>();
	public List<GameObject> goalL = new List<GameObject>();
	public List<GameObject> waterL = new List<GameObject>();
	public List<GameObject> dekoL = new List<GameObject>();
	public List<GameObject> playerL = new List<GameObject>();
	
	public List<Stuff> history = new List<Stuff>();
	public GameObject undoB;
	public GameObject redoB;

	//things
	public GameObject ground;
	public GameObject water;
	public GameObject deko;
	public GameObject obstacle;
	public GameObject player;
	public GameObject goal;
	public open menu;
	bool reddo = true;
	int HisPos = 0;

	public void undoo () {
		if(!reddo && HisPos != 1){
			if(history[HisPos-1].delete ){
				HisPos++;
				print("lololololololololololol");
			}
			
			
		}
		if(!history[HisPos-1].delete ){
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
		if(reddo && history[HisPos].delete){
			blub(false, HisPos);
			HisPos++;
			if(HisPos >= history.Count-1){
				redoB.SetActive(false);
			}
			return;
		}
		if(history.Count > HisPos+1){
			if(!history[HisPos+1].delete && history[HisPos+1].ae && !history[HisPos+2].ae){
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
	public void add (GameObject thing, bool delete, bool ae) {
		redoB.SetActive(false);
		reddo = true;
		for(int j = history.Count-1; j>HisPos-1; j--){
			history.RemoveAt(j);
		}
		
		HisPos++;

		if(thing.tag == "water"){
			history.Add(new Stuff(thing.GetComponent<Draggable>().ObjectLPos, thing.transform.position,thing.transform.localScale,thing.transform.rotation,thing.GetComponent<SpriteRenderer>().color, delete, thing.tag,
			new Vector2(thing.GetComponent<water>().waterForceX,thing.GetComponent<water>().waterForceY), ae));
		}
		else{
			history.Add(new Stuff(thing.GetComponent<Draggable>().ObjectLPos, thing.transform.position,thing.transform.localScale,thing.transform.rotation,thing.GetComponent<SpriteRenderer>().color, delete,thing.tag, new Vector2(0,0),ae));
		}
		//int i = history.Count-1;
		//print(history[i].thing+""+history[i].pos+""+ history[i].scale+""+ history[i].rotation+""+ history[i].color);
		undoB.SetActive(true);
		
	}
	void blub(bool unddo, int Pos){

		GameObject thing = GetObject(history[Pos].tag, history[Pos].number, Pos);
		
		
		

		if(history[Pos].delete && thing != null){
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
		
		else if(thing == null){
			GameObject thingy = null;
			Stuff lol = history[Pos];
			switch(history[Pos].tag){
				
				case "ground":
					thingy = GameObject.Instantiate(ground,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					groundL[history[Pos].number] = thingy;
					break;

				case "water":
					thingy = GameObject.Instantiate(water,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					thingy.GetComponent<water>().waterForceY = lol.WaterPower.y;
					thingy.GetComponent<water>().waterForceX = lol.WaterPower.x;
					thingy.GetComponent<water>().colorChanged = true;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					waterL[history[Pos].number] = thingy;
					
					break;

				case "obstacle":
					thingy = GameObject.Instantiate(obstacle,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					obstacleL[history[Pos].number] = thingy;
					break;

				case "goal":
					thingy = GameObject.Instantiate(goal,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					goalL[history[Pos].number] = thingy;
					break;
				
				case "deko":
					thingy = GameObject.Instantiate(deko,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					dekoL[history[Pos].number] = thingy;
						/*if(info.Length >5){
							thing.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(info[5]);
						}
						else{
							thing.GetComponent<SpriteRenderer>().sortingOrder = GameObject.FindGameObjectsWithTag("deko").Length-1;
						}*/
					
					break;
				
				case "Player":
					thingy = GameObject.Instantiate(player,lol.pos,lol.rotation);
					thingy.transform.localScale = lol.scale;
					thingy.GetComponent<SpriteRenderer>().color = lol.color;
					playerL[history[Pos].number] = thingy;
					thingy.GetComponent<Draggable>().ObjectLPos = lol.number;
					break;
				default:
					print("lol");
				break;
			}
			//history[HisPos]=(new Stuff(thingy, lol.pos,lol.scale,lol.rotation,lol.color, lol.delete, lol.tag,lol.WaterPower));

			
		}
		else{
			Stuff lol = history[Pos];
			thing.transform.position = lol.pos;
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
			}
		}
	}
	GameObject GetObject(string tag, int nummer, int pos){
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
	}
}
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

}

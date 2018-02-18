using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class loadLevel : MonoBehaviour {

	public GameObject ground;
	public GameObject water;
	public GameObject obstacle;
	public GameObject goal;
	public GameObject deko;
	public GameObject player;
	public TMP_InputField InputField;
	public TMP_InputField InputField2;
	public static string SaveName;
	public static bool usesaveName;
	public undo undoThing;
	//bool randomy = false;
	public leftright leftright;
	public GameObject cam;
	public Image bgcol1;
	public Image bgcol2;
	public PhysicsMaterial2D circlePhysics;
	public Sprite[] shapes;

	 const string characters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
	void Start () {
		if(openFile.jaa){
			readFile(openFile.path);
			usesaveName = true;
			openFile.jaa = false;
			

			string[] splitString = openFile.path.Split(new char[]{'/','\\'});
			SaveName = splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
			if(Application.loadedLevel == 1){
				isSomethingOpen.modified = false;
				if(InputField != null){
				InputField.text = SaveName;
				}
			}
			
			
			

		}
		else if(playCustom.jaa){
			readFile(playCustom.path2);
			string[] splitString = playCustom.path2.Split(new char[]{'/','\\'});
			SaveName = splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
			InputField.text = SaveName;
			//InputField2.text = SaveName;
			
		}
		else if(save.tempoPlay){
			readFile(Application.persistentDataPath+"/temporary/temporary.txt");
			if(usesaveName){
				InputField.text = SaveName;
			}
				
			if(Application.loadedLevel == 1){
				save.tempoPlay = false;
				
			}
			else if(usesaveName){
				InputField2.text = SaveName;
			}
		}
		else if(changeSceneOnline.tempo){
			readFile(Application.persistentDataPath+"/temporary/temporaryOnline.txt");

		}
		if(Application.loadedLevel == 1){
			if(GameObject.FindGameObjectWithTag("Player")){
				Transform player =GameObject.FindGameObjectWithTag("Player").transform;
				transform.position = new Vector3(player.position.x,player.position.y,-10);
			}
			
			/*if(!randomy){
				for(int i = 0; i<9; i++){
					random += characters[Random.Range(0,characters.Length)];
					
				}
				print(random);
			}*/
		}
	}
	void readFile(string FilePath){

		//CompressionHelper.DecompressFile(FilePath);
		/*StreamReader sReader = new StreamReader(FilePath);
		string file = sReader.ReadToEnd();
		sReader.Close();*/
		byte[] bytes = File.ReadAllBytes(FilePath);
		print(bytes[0]);
		string file;
		if(bytes[0] == 21)
			file = System.Text.Encoding.UTF8.GetString(CLZF2.Decompress(bytes));
		else
			file = System.Text.Encoding.UTF8.GetString(bytes);
		//string file =  System.Text.Encoding.UTF8.GetString(bytes);
		//CompressionHelper.DecompressString(file);
		string[] strings = file.Split('\n');
		
		for(int i = 0; i<strings.Length; i++){
			int shape = 0;
			Quaternion rot;

			//string line = sReader.ReadLine();
			string[] info = strings[i].Split(new char[]{';'});
			if(info.Length > 3){
				rot = StringToQuaternion(info[3]);
			}
			else{
				rot = Quaternion.identity;
			}
			GameObject thing = null;
			switch(info[0]){
				
				case "gr":
					thing = GameObject.Instantiate(ground,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							shape = int.Parse(info[5]);
							if(info.Length > 6){
								if(Application.loadedLevel == 2){
									thing.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = float.Parse(info[6]);
									if(info[7] == "1"){
										thing.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
										thing.GetComponent<detectWater>().ok = true;
									}
								}
								else{
									Draggable dragy = thing.GetComponent<Draggable>();
									dragy.bounciness = float.Parse(info[6]);
									dragy.falling = info[7]=="1";
								}
								
							}
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.groundL++;
					}
					break;

				case "wa":
					thing = GameObject.Instantiate(water,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							thing.GetComponent<water>().waterForceY = float.Parse(info[5]);
							thing.GetComponent<water>().waterForceX = float.Parse(info[6]);
							if(info.Length >6){
								thing.GetComponent<water>().colorChanged = info[7] == "1";
								if(info.Length > 8){
									shape = int.Parse(info[8]);
								}
							}
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.waterL++;
					}
					break;

				case "ob":
					thing = GameObject.Instantiate(obstacle,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							shape = int.Parse(info[5]);
							if(info.Length > 6){
								if(Application.loadedLevel == 2){
									thing.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = float.Parse(info[6]);
									if(info[7] == "1"){
										thing.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
										thing.GetComponent<detectWater>().ok = true;
									}
								}
								else{
									Draggable dragy = thing.GetComponent<Draggable>();
									dragy.bounciness = float.Parse(info[6]);
									dragy.falling = info[7]=="1";
								}
							}
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.obstacleL++;
					}
					break;

				case "go":
					thing = GameObject.Instantiate(goal,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							shape = int.Parse(info[5]);
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.goalL++;
					}
					break;
				
				case "de":
					thing = GameObject.Instantiate(deko,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							shape = int.Parse(info[5]);
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.dekoL++;
					}
					break;
				
				case "pl":
					thing = GameObject.Instantiate(player,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToScale(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							shape = int.Parse(info[5]);
							if(shape ==1 && Application.loadedLevel == 2){
								thing.GetComponent<Rigidbody2D>().sharedMaterial = circlePhysics;
								thing.GetComponent<move>().UseCustomFriction = false;
							}
							if(info.Length > 6){
								if(Application.loadedLevel == 2){
									thing.GetComponent<Rigidbody2D>().sharedMaterial.bounciness = float.Parse(info[6]);
								}
								else{
									 thing.GetComponent<Draggable>().bounciness = float.Parse(info[6]);
								}
							}
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.playerL++;
					}
					break;
				/*case "random":
					random =info[1];
					randomy = true;
					break;*/
				case "bg":
					string[] farben = info[1].Split(',');
					Color col1 = new Color(float.Parse(farben[0]),float.Parse(farben[1]),float.Parse(farben[2]),1);
					Color col2 = new Color(float.Parse(farben[3]),float.Parse(farben[4]),float.Parse(farben[5]),1);
					if(Application.loadedLevel == 1){
						cam.GetComponent<FarbenLager>().bg1 = col1;
						cam.GetComponent<FarbenLager>().bg2 = col2;
						cam.GetComponent<Camera>().backgroundColor = col1;
						bgcol1.color = col1;
						bgcol2.color = col2;
					}
					else{
						cam.GetComponent<Camera>().backgroundColor = col1;
						cam.GetComponent<backgroundColor>().color1 = col1;
						cam.GetComponent<backgroundColor>().color2 = col2;
					}
					break;
				default:
				print("lol");
				break;
			}
			if(thing != null){
				if(thing.tag != "deko" || Application.loadedLevel != 2){
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
				}
				
				thing.GetComponent<SpriteRenderer>().sprite = shapes[shape];
				
			}
			
			
			if(Application.loadedLevel == 1 && thing != null){
				undoThing.allThings.Add(thing);
				thing.GetComponent<Draggable>().ObjectLPos = undoThing.allThings.Count-1;
				thing.GetComponent<Draggable>().Shape = shape;
			}
			else if(Application.loadedLevel == 2){
				leftright.addPlayers();
			}
			/*if(info[0] == "ground"){
				GameObject thing = GameObject.Instantiate(ground,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
				}
			}
			if(info[0] == "water"){
				GameObject thing = GameObject.Instantiate(water,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					if(info.Length > 5){
						thing.GetComponent<water>().waterForceY = float.Parse(info[5]);
						thing.GetComponent<water>().waterForceX = float.Parse(info[6]);
					}
				}
			}
			if(info[0] == "obstacle"){
				GameObject thing = GameObject.Instantiate(obstacle,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
				}
			}
			if(info[0] == "goal"){
				GameObject thing = GameObject.Instantiate(goal,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
				}
			}
			if(info[0] == "deko"){
				GameObject thing = GameObject.Instantiate(deko,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					if(info.Length >5){
						thing.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(info[5]);
					}
					else{
						thing.GetComponent<SpriteRenderer>().sortingOrder = GameObject.FindGameObjectsWithTag("deko").Length-1;
					}
				}
			}
			if(info[0] == "player"){
				GameObject thing = GameObject.Instantiate(player,StringToVector3(info[1]),rot);
				thing.transform.localScale = StringToVector3(info[2]);
				if(info.Length > 4){
					thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
				}
			}*/


		}

		//sReader.Close();

	}
	
	public static Vector3 StringToVector3(string sVector)
     {
         // Remove the parentheses
        
 
         // split the items
         string[] sArray = sVector.Split(',');
 
         // store as a Vector3
         Vector3 result = new Vector3(
             float.Parse(sArray[0]),
             float.Parse(sArray[1]),
             float.Parse(sArray[2]));
 
         return result;
     }

	 public static Vector3 StringToScale(string sVector)
     {
         // Remove the parentheses
        
 
         // split the items
         string[] sArray = sVector.Split(',');
 
         // store as a Vector3
         Vector3 result = new Vector3(
             float.Parse(sArray[0]),
             float.Parse(sArray[1]),0);
 
         return result;
     }

	 public static Quaternion StringToQuaternion(string sQuaternion)
     {
         // Remove the parentheses
         /*if (sQuaternion.StartsWith ("(") && sQuaternion.EndsWith (")")) {
             sQuaternion = sQuaternion.Substring(1, sQuaternion.Length-2);
         }*/
 
         // split the items
 
         // store as a Vector3
         Quaternion result = Quaternion.Euler(0,0,float.Parse(sQuaternion));
 
         return result;
     }
	 public static Color StringToColor(string sColor)
     {
         // Remove the parentheses
 
         // split the items
         string[] sArray = sColor.Split(',');
 
         // store as a Vector3
         Color result = new Color(
			 float.Parse(sArray[0]),
			 float.Parse(sArray[1]),
			 float.Parse(sArray[2]),
			 float.Parse(sArray[3]));
 
         return result;
     }
}

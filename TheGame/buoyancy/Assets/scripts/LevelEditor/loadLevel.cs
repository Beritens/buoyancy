using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class loadLevel : MonoBehaviour {

	public GameObject ground;
	public GameObject water;
	public GameObject obstacle;
	public GameObject goal;
	public GameObject deko;
	public GameObject player;
	public GameObject InputField;
	public static string SaveName;
	public static bool useSaveName;
	public undo undoThing;
	void Start () {
		if(openFile.jaa){
			readFile(openFile.path);
			openFile.jaa = false;
			useSaveName = true;
			

			string[] splitString = openFile.path.Split(new char[]{'/','\\'});
			SaveName = splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
			if(Application.loadedLevel == 1){
				isSomethingOpen.modified = false;
				if(InputField != null){
				InputField.GetComponent<TMP_InputField>().text = SaveName;
				}
			}
			
			
			

		}
		else if(playCustom.jaa){
			readFile(playCustom.path2);
			
		}
		else if(save.tempoPlay){
			readFile(Application.persistentDataPath+"/temporary/temporary.txt");
			if(Application.loadedLevel == 1){
				save.tempoPlay = false;
				if(useSaveName){
					InputField.GetComponent<TMP_InputField>().text = SaveName;
				}
			}
		}
		if(Application.loadedLevel == 1 && GameObject.FindGameObjectWithTag("Player")){
			Transform player =GameObject.FindGameObjectWithTag("Player").transform;
			transform.position = new Vector3(player.position.x,player.position.y,-10);
		}
	}
	void readFile(string FilePath){
		StreamReader sReader = new StreamReader(FilePath);
		while(!sReader.EndOfStream){
			Quaternion rot;

			string line = sReader.ReadLine();
			string[] info = line.Split(new char[]{';'});
			if(info.Length > 3){
				rot = StringToQuaternion(info[3]);
			}
			else{
				rot = Quaternion.identity;
			}
			GameObject thing;
			switch(info[0]){
				
				case "ground":
					thing = GameObject.Instantiate(ground,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					}
					if(Application.loadedLevel == 1){
						undoThing.groundL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.groundL.Count-1;
					}
					break;

				case "water":
					thing = GameObject.Instantiate(water,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						if(info.Length > 5){
							thing.GetComponent<water>().waterForceY = float.Parse(info[5]);
							thing.GetComponent<water>().waterForceX = float.Parse(info[6]);
							if(info.Length >6){
								thing.GetComponent<water>().colorChanged = info[7] == "true";
							}
						}
					}
					if(Application.loadedLevel == 1){
						undoThing.waterL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.waterL.Count-1;
					}
					break;

				case "obstacle":
					thing = GameObject.Instantiate(obstacle,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					}
					if(Application.loadedLevel == 1){
						undoThing.obstacleL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.obstacleL.Count-1;
					}
					break;

				case "goal":
					thing = GameObject.Instantiate(goal,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					}
					if(Application.loadedLevel == 1){
						undoThing.goalL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.goalL.Count-1;
					}
					break;
				
				case "deko":
					thing = GameObject.Instantiate(deko,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
						/*if(info.Length >5){
							thing.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(info[5]);
						}
						else{
							thing.GetComponent<SpriteRenderer>().sortingOrder = GameObject.FindGameObjectsWithTag("deko").Length-1;
						}*/
					}
					if(Application.loadedLevel == 1){
						undoThing.dekoL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.dekoL.Count-1;
					}
					break;
				
				case "player":
					thing = GameObject.Instantiate(player,StringToVector3(info[1]),rot);
					thing.transform.localScale = StringToVector3(info[2]);
					
					
					if(info.Length > 4){
						thing.GetComponent<SpriteRenderer>().color = StringToColor(info[4]);
					}
					if(Application.loadedLevel == 1){
						undoThing.playerL.Add(thing);
						thing.GetComponent<Draggable>().ObjectLPos = undoThing.playerL.Count-1;
					}
					break;
				default:
				print("lol");
				break;
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

		sReader.Close();

	}
	
	public static Vector3 StringToVector3(string sVector)
     {
         // Remove the parentheses
         if (sVector.StartsWith ("(") && sVector.EndsWith (")")) {
             sVector = sVector.Substring(1, sVector.Length-2);
         }
 
         // split the items
         string[] sArray = sVector.Split(',');
 
         // store as a Vector3
         Vector3 result = new Vector3(
             float.Parse(sArray[0]),
             float.Parse(sArray[1]),
             float.Parse(sArray[2]));
 
         return result;
     }

	 public static Quaternion StringToQuaternion(string sQuaternion)
     {
         // Remove the parentheses
         if (sQuaternion.StartsWith ("(") && sQuaternion.EndsWith (")")) {
             sQuaternion = sQuaternion.Substring(1, sQuaternion.Length-2);
         }
 
         // split the items
         string[] sArray = sQuaternion.Split(',');
 
         // store as a Vector3
         Quaternion result = new Quaternion(
			 float.Parse(sArray[0]),
			 float.Parse(sArray[1]),
			 float.Parse(sArray[2]),
			 float.Parse(sArray[3]));
 
         return result;
     }
	 public static Color StringToColor(string sColor)
     {
         // Remove the parentheses
         if (sColor.StartsWith ("RGBA(") && sColor.EndsWith (")")) {
             sColor = sColor.Substring(5, sColor.Length-6);
         }
 
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

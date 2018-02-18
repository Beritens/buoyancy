using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class save : MonoBehaviour {

	private string filePath;
	public TMP_InputField text;
	private string folderName = "customLevels";
	public string fileName = "1.txt";
	public openSomething openStuff;
	public loadLevel ll;

	private string tempofolderName = "temporary";
	public string tempofileName = "temporary";
	public static bool tempoPlay;
	public bool tempo = false;
	public FarbenLager cam;
	public message message;
	
	void Start(){
		
		if(!tempo){
			filePath = Application.persistentDataPath+"/"+folderName;
		}
		else{
			filePath = Application.persistentDataPath+"/"+tempofolderName;
		}
		
	}
	public void saveMe(){
		 
		if(!tempo){
			loadLevel.usesaveName = true;
			fileName = text.text+".txt";
			loadLevel.SaveName = text.text;
		}
		else{
			fileName = tempofileName+".txt";
		}
		
		if (!Directory.Exists (filePath)) {
			
         	Directory.CreateDirectory (filePath);
    	}

		StreamWriter sWriter;
		if(!File.Exists(filePath+"/"+fileName)){
			sWriter = File.CreateText(filePath+"/"+fileName);
		}
		else{
			sWriter = new StreamWriter(filePath+"/"+fileName);
		}
		GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] ground = GameObject.FindGameObjectsWithTag("ground");
		GameObject[] water = GameObject.FindGameObjectsWithTag("water");
		GameObject[] obstacle = GameObject.FindGameObjectsWithTag("obstacle");
		GameObject[] deko = GameObject.FindGameObjectsWithTag("deko");
		GameObject[] goal = GameObject.FindGameObjectsWithTag("goal");
		
		//sWriter.WriteLine("random;"+ll.random);
		sWriter.WriteLine("bg;"+cam.bg1.r.ToString()+","+cam.bg1.g.ToString()+","+cam.bg1.b.ToString()+","+cam.bg2.r.ToString()+","+cam.bg2.g.ToString()+","+cam.bg2.b.ToString());

		
		if(ground != null || ground.Length != 0){
			for(int i = 0; i<ground.Length;i++){
				string pos = posy(ground[i].transform.position);
				string size = scaly(ground[i].transform.localScale);
				string rot = roty(ground[i].transform.rotation);
				string col = coly(ground[i].GetComponent<SpriteRenderer>().color);
				Draggable dragy = ground[i].GetComponent<Draggable>();
				string shape = dragy.Shape.ToString();
				string physics = dragy.bounciness.ToString("0.####") + ";";
				if(dragy.falling){
					physics+="1";
				}
				else{
					physics+="0";
				}
				sWriter.WriteLine("gr"+";"+pos+";"+size+";"+rot+";"+col+";"+shape+";"+physics);
			}
		}
		if(water != null || water.Length != 0){
			for(int i = 0; i<water.Length;i++){
				string pos = posy(water[i].transform.position);
				string size = scaly(water[i].transform.localScale);
				string rot = roty(water[i].transform.rotation);
				string col = coly(water[i].GetComponent<SpriteRenderer>().color);
				water watery = water[i].GetComponent<water>();
				string pow =watery.waterForceY.ToString("0.####") + ";" + watery.waterForceX.ToString("0.####");
				string colChange;
				if(water[i].GetComponent<water>().colorChanged){
					colChange = "1";
				}
				else{
					colChange = "0";
				}
				string shape = water[i].GetComponent<Draggable>().Shape.ToString();
				sWriter.WriteLine("wa"+";"+pos+";"+size+";"+rot+";"+col+";"+pow+";"+colChange+";"+shape);
			}
		}
		if(obstacle != null || obstacle.Length != 0){
			for(int i = 0; i<obstacle.Length;i++){
				string pos = posy(obstacle[i].transform.position);
				string size = scaly(obstacle[i].transform.localScale);
				string rot = roty(obstacle[i].transform.rotation);
				string col = coly(obstacle[i].GetComponent<SpriteRenderer>().color);
				Draggable dragy =obstacle[i].GetComponent<Draggable>();
				string shape = dragy.Shape.ToString();
				string physics = dragy.bounciness.ToString("0.####") + ";";
				if(dragy.falling){
					physics+="1";
				}
				else{
					physics+="0";
				}
				sWriter.WriteLine("ob"+";"+pos+";"+size+";"+rot+";"+col+";"+shape +";"+physics);
			}
		}
		if(goal != null || goal.Length != 0){
			for(int i = 0; i<goal.Length;i++){
				string pos = posy(goal[i].transform.position);
				string size = scaly(goal[i].transform.localScale);
				string rot = roty(goal[i].transform.rotation);
				string col = coly(goal[i].GetComponent<SpriteRenderer>().color);
				string shape = goal[i].GetComponent<Draggable>().Shape.ToString();
				sWriter.WriteLine("go"+";"+pos+";"+size+";"+rot+";"+col+";"+shape);
			}
		}
		if(deko != null || deko.Length != 0){
			for(int i = 0; i<deko.Length;i++){
				string pos = posy(deko[i].transform.position);
				string size = scaly(deko[i].transform.localScale);
				string rot = roty(deko[i].transform.rotation);
				string col = coly(deko[i].GetComponent<SpriteRenderer>().color);
				string shape = deko[i].GetComponent<Draggable>().Shape.ToString();
				sWriter.WriteLine("de"+";"+pos+";"+size+";"+rot+";"+col+";"+shape);
			}
		}
		if(player != null || player.Length != 0){
			for(int i = 0; i<player.Length;i++){
				string pos = posy(player[i].transform.position);
				string size = scaly(player[i].transform.localScale);
				string rot = roty(player[i].transform.rotation);
				string col = coly(player[i].GetComponent<SpriteRenderer>().color);
				Draggable dragy = player[i].GetComponent<Draggable>();
				string shape = dragy.Shape.ToString();
				string physics = dragy.bounciness.ToString("0.####");
				sWriter.WriteLine("pl"+";"+pos+";"+size+";"+rot+";"+col+";"+shape+";"+physics);
			}
		}
		sWriter.WriteLine("end");
		sWriter.Close();
		

		if(!tempo){
			isSomethingOpen.modified = false;
			openStuff.close();
			message.Message("Level saved");
		}
		else{

			tempoPlay = true;
			Application.LoadLevel(2);
		}
		
		
		
	}
	string coly(Color color){
		string lol;
		lol = color.r.ToString("0.###") + "," + color.g.ToString("0.###") + "," + color.b.ToString("0.###") + "," + color.a.ToString("0.###");
		return lol;
	}
	string posy(Vector3 position){
		string lol;
		lol = position.x.ToString("0.###") +","+ position.y.ToString("0.###") +","+ position.z.ToString("0.###");
		return lol;
	}
	string scaly(Vector3 scale){
		string lol;
		lol = scale.x.ToString("0.###") +","+ scale.y.ToString("0.###");
		return lol;
	}
	string roty(Quaternion rotation){
		string lol;
		lol = rotation.eulerAngles.z.ToString("0.###");
		return lol;
	}
}

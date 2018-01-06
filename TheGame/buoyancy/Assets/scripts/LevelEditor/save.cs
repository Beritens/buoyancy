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

	private string tempofolderName = "temporary";
	public string tempofileName = "temporary";
	public static bool tempoPlay;
	public bool tempo = false;
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
			fileName = text.text+".txt";
		}
		else{
			fileName = tempofileName+".txt";
		}
		
		print(filePath);
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
		
		
		if(ground != null || ground.Length != 0){
			for(int i = 0; i<ground.Length;i++){
				string pos = ground[i].transform.position.ToString("F3");
				string size = ground[i].transform.localScale.ToString("F3");
				string rot = ground[i].transform.rotation.ToString("F3");
				string col = ground[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				sWriter.WriteLine("ground"+";"+pos+";"+size+";"+rot+";"+col);
			}
		}
		if(water != null || water.Length != 0){
			for(int i = 0; i<water.Length;i++){
				string pos = water[i].transform.position.ToString("F3");
				string size = water[i].transform.localScale.ToString("F3");
				string rot = water[i].transform.rotation.ToString("F3");
				string col = water[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				string pow = water[i].GetComponent<water>().waterForceY.ToString() + ";" + water[i].GetComponent<water>().waterForceX.ToString();
				string colChange = water[i].GetComponent<water>().colorChanged.ToString();
				sWriter.WriteLine("water"+";"+pos+";"+size+";"+rot+";"+col+";"+pow+";"+colChange);
			}
		}
		if(obstacle != null || obstacle.Length != 0){
			for(int i = 0; i<obstacle.Length;i++){
				string pos = obstacle[i].transform.position.ToString("F3");
				string size = obstacle[i].transform.localScale.ToString("F3");
				string rot = obstacle[i].transform.rotation.ToString("F3");
				string col = obstacle[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				sWriter.WriteLine("obstacle"+";"+pos+";"+size+";"+rot+";"+col);
			}
		}
		if(goal != null || goal.Length != 0){
			for(int i = 0; i<goal.Length;i++){
				string pos = goal[i].transform.position.ToString("F3");
				string size = goal[i].transform.localScale.ToString("F3");
				string rot = goal[i].transform.rotation.ToString("F3");
				string col = goal[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				sWriter.WriteLine("goal"+";"+pos+";"+size+";"+rot+";"+col);
			}
		}
		if(deko != null || deko.Length != 0){
			for(int i = 0; i<deko.Length;i++){
				string pos = deko[i].transform.position.ToString("F3");
				string size = deko[i].transform.localScale.ToString("F3");
				string rot = deko[i].transform.rotation.ToString("F3");
				string col = deko[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				//string order = deko[i].GetComponent<SpriteRenderer>().sortingOrder.ToString();
				sWriter.WriteLine("deko"+";"+pos+";"+size+";"+rot+";"+col/*+";"+order*/);
			}
		}
		if(player != null || player.Length != 0){
			for(int i = 0; i<player.Length;i++){
				string pos = player[i].transform.position.ToString("F3");
				string size = player[i].transform.localScale.ToString("F3");
				string rot = player[i].transform.rotation.ToString("F3");
				string col = player[i].GetComponent<SpriteRenderer>().color.ToString("F3");
				sWriter.WriteLine("player"+";"+pos+";"+size+";"+rot+";"+col);
			}
		}
		sWriter.Close();

		if(!tempo){
			isSomethingOpen.modified = false;
			openStuff.close();
		}
		else{
			tempoPlay = true;
			print(tempoPlay);
			Application.LoadLevel(2);
		}
		
		
		
	}
}

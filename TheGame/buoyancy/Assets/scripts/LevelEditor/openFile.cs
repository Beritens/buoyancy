using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFile : MonoBehaviour {

	public string ThePath;
	public static string path;
	public static bool jaa;
	
	public void click(){
		
		if(isSomethingOpen.modified){
			GameObject QuestionStuff = GameObject.Find("QuestionStuff");
			QuestionStuff.GetComponent<question>().Anfrage(1);
			QuestionStuff.GetComponent<question>().path = ThePath;
			GameObject.Find("Open LoadMenu").GetComponent<openLoadMenu>().close();
		}
		else{
			jaa = true;
			path = ThePath;
			Application.LoadLevel(1);
		}
		
	}
	

}

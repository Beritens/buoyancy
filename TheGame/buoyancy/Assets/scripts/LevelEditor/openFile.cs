using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFile : MonoBehaviour {

	public string ThePath;
	public static string path;
	public static bool jaa;
	
	public void click(){
		jaa = true;
		path = ThePath;
		if(isSomethingOpen.modified){
			GameObject.Find("QuestionStuff").GetComponent<question>().Anfrage(true);
			GameObject.Find("Open LoadMenu").GetComponent<openLoadMenu>().close();
		}
		else{
			Application.LoadLevel(1);
		}
		
	}
	

}

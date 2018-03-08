using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class playCustom : MonoBehaviour {

	public string ThePath;
	public static string path2;
	public static bool jaa;
	

	
	
	public void click(){
		if(GameObject.Find("Trash")){
			if(!GameObject.Find("Trash").GetComponent<Trash>().trashOpen){
				jaa = true;
				path2 = ThePath;
				Application.LoadLevel(2);
			}
			else{
				GameObject.Find("rlyController").GetComponent<openSomething>().open();
				string[] splitString = ThePath.Split(new char[]{'/','\\'});
				GameObject.Find("rlyText").GetComponent<TextMeshProUGUI>().text = "are you sure that you want to delete " + splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
				delPlaceholder lol = GameObject.Find("yesDelete").GetComponent<delPlaceholder>();
				lol.buttonLocal = this;
				lol.online = false;
			}
			
		}
		else{
			jaa = true;
			path2 = ThePath;
			Application.LoadLevel(2);
		}
		
	}
	public void dele(){
		File.Delete(ThePath);
		GameObject.Find("rlyController").GetComponent<openSomething>().close();
		GameObject.Destroy(gameObject);
		
	}
	

}

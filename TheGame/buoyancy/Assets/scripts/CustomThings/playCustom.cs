using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
				File.Delete(ThePath);
				GameObject.Destroy(gameObject);
			}
			
		}
		else{
			jaa = true;
			path2 = ThePath;
			Application.LoadLevel(2);
		}
		
	}
	

}

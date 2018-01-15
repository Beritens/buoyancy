using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Back : MonoBehaviour {

	public GameObject backButton;
	public GameObject online;
	public TMP_InputField NameThing;

	void Start () {
		if(!changeSceneOnline.tempo){
			
			online.SetActive(true);
			if(!PlayerPrefs.HasKey("name")){
				PlayerPrefs.SetString("name","");
			}
			if(save.tempoPlay){
				backButton.SetActive(true);
				NameThing.text = PlayerPrefs.GetString("name");
			}
			
		}
	}
	public void click(){
		Application.LoadLevel(1);
	}
	
}

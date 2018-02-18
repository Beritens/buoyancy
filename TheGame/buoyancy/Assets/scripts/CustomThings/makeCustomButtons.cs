using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class makeCustomButtons : MonoBehaviour {

	// Use this for initialization
	public Transform container;
	public GameObject button;
	public void Start(){
		if (Directory.Exists (Application.persistentDataPath+"/customLevels")){
			string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath+"/customLevels");
		
			for(int i = 0; i<files.Length; i++){
				string[] splitString = files[i].Split(new char[]{'/','\\'});
				GameObject thisButton =GameObject.Instantiate(button,transform.position,Quaternion.identity);
				thisButton.GetComponent<playCustom>().ThePath = files[i];
				
				thisButton.transform.parent = container;
				thisButton.transform.localScale = new Vector3(1,1,1);
				thisButton.GetComponentInChildren<TextMeshProUGUI>().text = splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
			}
			container.GetComponent<RectTransform>().sizeDelta = new Vector2(404,Mathf.Ceil(files.Length/4f)*70+files.Length);
		}
		
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class load : MonoBehaviour {

	public Transform container;
	public GameObject button;
	public void GetFile(){
		
		string[] files = System.IO.Directory.GetFiles(Application.persistentDataPath+"/customLevels");
		container.GetComponent<RectTransform>().anchorMax = new Vector2(files.Length*0.5f,container.GetComponent<RectTransform>().anchorMax.y);
		for(int i = 0; i<files.Length; i++){
			string[] splitString = files[i].Split(new char[]{'/','\\'});
			GameObject thisButton =GameObject.Instantiate(button,transform.position,Quaternion.identity);
			thisButton.GetComponent<openFile>().ThePath = files[i];
			thisButton.transform.parent = container;
			thisButton.GetComponentInChildren<TextMeshProUGUI>().text = splitString[splitString.Length-1].Substring(0, splitString[splitString.Length-1].Length-4);
		}
	}
}

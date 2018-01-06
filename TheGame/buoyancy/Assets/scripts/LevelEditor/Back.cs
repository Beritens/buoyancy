using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

	public GameObject backButton;
	void Start () {
		print("hi");
		if(save.tempoPlay){
			backButton.SetActive(true);
		}
	}
	public void click(){
		Application.LoadLevel(1);
	}
	
}

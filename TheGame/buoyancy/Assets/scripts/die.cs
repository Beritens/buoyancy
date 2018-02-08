using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D col){
		
		if(col.gameObject.tag == "Player" && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<inGoal>().inTheGoal == false){
			Time.timeScale = 1;
			Application.LoadLevel(Application.loadedLevel);

		}
	}
}

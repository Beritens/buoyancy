using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	 Transform player;
  
	void Start(){

		//Ich pack das einfach mal hier hin
		/*if(!PlayerPrefs.HasKey("buttonSize"))
		 {
 			PlayerPrefs.SetFloat("buttonSize",0.5f);
		 }*/


		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
	}
  	void Update () 
 	 {
		if(player != null){
			if(player.position.y > -20){
				transform.position = new Vector3(player.position.x,player.position.y,-10);
			}
			else if(player.position.y < -30 && GetComponent<inGoal>().inTheGoal == false){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		else if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
		
     	 
 	 }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpToPlayer : MonoBehaviour {

	public Transform cam;
	public void tp () {
		if(GameObject.FindGameObjectWithTag("Player")){
			Transform player =GameObject.FindGameObjectWithTag("Player").transform;
			cam.position = new Vector3(player.position.x,player.position.y,cam.position.z);
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpToBlock : MonoBehaviour {

	public Transform cam;
	public void tp () {
		if(GameObject.Find("sizeStuff(Clone)")){
			Transform block =GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
			cam.position = new Vector3(block.position.x,block.position.y,cam.position.z);
		}
		else if(GameObject.FindGameObjectWithTag("Player")){
			Transform player =GameObject.FindGameObjectWithTag("Player").transform;
			cam.position = new Vector3(player.position.x,player.position.y,cam.position.z);
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {


	Transform player;
	// Use this for initialization
	MeshRenderer mr;
	Material mat;
	public float parallax = 2;
	
	void Start () {
		/*transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y,0);
		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}*/
		mr = GetComponent<MeshRenderer>();
		mat = mr.material;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(player.position.y >= transform.position.y + 26){
			transform.Translate(new Vector3(0,26,0));
		}
		if(player.position.y <= transform.position.y - 26){
			transform.Translate(new Vector3(0,-26,0));
		}
		if(player.position.x >= transform.position.x + 26){
			transform.Translate(new Vector3(26,0,0));
		}
		if(player.position.x <= transform.position.x - 26){
			transform.Translate(new Vector3(-26,0,0));
		}*/
		Vector2 offset = mat.mainTextureOffset;
		offset = transform.position / parallax;
		mat.mainTextureOffset = offset;

		
		
	}
}

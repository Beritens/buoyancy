using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundColor : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D player;
	public Color color1;
	public Color color2;
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){
			//GetComponent<Camera>().backgroundColor = Color.Lerp(color1,color2,player.velocity.magnitude/40);
			GetComponent<Camera>().backgroundColor = Color.Lerp(color1,color2,player.velocity.magnitude/40);
		}
		else if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		}
	}
}

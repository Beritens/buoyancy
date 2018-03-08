using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundColor : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D player;
	public Color color1;
	public Color color2;
	//public AudioSource audioS;
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){
			//GetComponent<Camera>().backgroundColor = Color.Lerp(color1,color2,player.velocity.magnitude/40);
			float lol = player.velocity.magnitude/40;
			GetComponent<Camera>().backgroundColor = Color.Lerp(color1,color2,lol);
			//audioS.volume = Mathf.Clamp(lol,0,1);

		}
		else if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public float speed = 2f;
	public float jump = 3f;
	public float radius = 1f;
	public float distance = 1f;
	public bool grounded = false;
	public bool previouslyGrounded = false;
	public float friction = 0.95f;
	//public Color color1;
	//public Color color2;
	GameObject cameraa;
	bool inGoal = false;

	float leftrightinput;
	float waterForceX = 0f;
	float waterForceY = 0f;
	bool inWater;
	Rigidbody2D rb;
	List<Vector2> power = new List<Vector2>();

	// Use this for initialization

	void Start () {
		cameraa = GameObject.Find("Main Camera");
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update(){
		if(GameObject.Find("functions") != null){
			leftrightinput = GameObject.Find("functions").GetComponent<leftright>().leftorright;
		}

		
		//leftrightinput = GameObject.Find("Panel").GetComponent<leftrightcontrols>().leftrightcontrolinput;
		

		groundcheck();
		/*float r = Mathf.Clamp(0.217f + (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)/2 )/ 50,0.2f,0.7f);
		float g = Mathf.Clamp(0.327f - (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)/2 )/ 50,0.1f,0.8f);
		float b = Mathf.Clamp(0.500f - (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)/2 )/ 50,0.3f,0.8f);
		*/
		//cameraa.GetComponent<Camera>().backgroundColor = Color.Lerp(color1,color2,GetComponent<Rigidbody2D>().velocity.magnitude/40);

		if(Input.GetButtonDown("Jump")){
			Jump();
			
		}
		
		/*if(grounded){
			GetComponent<Rigidbody2D>().sharedMaterial.friction = 0.4f;

		}
		else{
			GetComponent<Rigidbody2D>().sharedMaterial.friction = 0f;
		}*/
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		
		float horizontal2 = Input.GetAxis("Horizontal") * speed * 10;
		float horizontal = leftrightinput * speed * 10;
		if(horizontal != 0){
			if(grounded){
				rb.AddForce(new Vector2(horizontal - (GetComponent<Rigidbody2D>().velocity.x*2f),0), ForceMode2D.Force);
			}
			else{
				rb.AddForce(new Vector2((horizontal - (GetComponent<Rigidbody2D>().velocity.x*2f))/2,0), ForceMode2D.Force);
			}
			
			
		}
		else if(horizontal2 != 0){
			if(grounded){
				rb.AddForce(new Vector2(horizontal2 - (GetComponent<Rigidbody2D>().velocity.x*2f),0), ForceMode2D.Force);
			}
			else{
				GetComponent<Rigidbody2D>().AddForce(new Vector2((horizontal2 - (GetComponent<Rigidbody2D>().velocity.x*2f))/2,0), ForceMode2D.Force);
			}
		}
		//lösch das später
		if(grounded){
			Vector2 vel = GetComponent<Rigidbody2D>().velocity;
			vel.x = vel.x * friction;
			rb.velocity = vel;
		}
		if(inWater){
			rb.AddForce(new Vector2(waterForceX,waterForceY)*25, ForceMode2D.Force);
		}

		
	}

	
	void groundcheck(){

		previouslyGrounded = grounded;


		RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, -Vector2.up, distance);
		if(hit.Length > 1){
			grounded = true;
		}
		else{
			grounded = false;
		}
		

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "water"){
			inWater = true;
			GetComponent<Rigidbody2D>().drag = 0.2f;
			power.Add(new Vector2(col.GetComponent<water>().waterForceX,col.GetComponent<water>().waterForceY));
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(waterForceX)){
				waterForceX = col.GetComponent<water>().waterForceX;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(waterForceY)){
				waterForceY = col.GetComponent<water>().waterForceY;
			}

			
		

			/*if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(waterForceY)){
				waterForceY = col.GetComponent<water>().waterForceY;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(waterForceX)){
				waterForceX = col.GetComponent<water>().waterForceX;
			}*/
			

			
		}
		if(col.tag == "goal" && inGoal == false){
			/*if(Application.loadedLevel == 1 || Application.loadedLevel == 2){
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<inGoal>().inTheGoal = true;
				if(save1.tempoPlay){
					
					Application.LoadLevel(1);
				}
				else{
					playCustom.jaa = false;
					Application.LoadLevel(0);
				}
				
			}*/
			
			cameraa.GetComponent<inGoal>().inTheGoal = true;
			if(Application.loadedLevel >2){
				if(PlayerPrefs.GetInt("unlockedLevel")<Application.loadedLevel+1){
				PlayerPrefs.SetInt("unlockedLevel", Application.loadedLevel+1);
				}
			}
			
			if(GameObject.Find("pause") && GameObject.Find("pause").GetComponent<openPauseMenu>().an == false){
				GameObject.Find("pause").GetComponent<openPauseMenu>().open();
			}
				
			
			inGoal = true;
		}
            
        
		
	}
	/*void OnTriggerEnter2D(Collider2D col){
		
		if(col.tag == "water"){
			
			if(col.GetComponent<water>().waterForceY > waterForceY){
				waterForceY = col.GetComponent<water>().waterForceY;
			}
			if(col.GetComponent<water>().waterForceX > waterForceX){
				waterForceX = col.GetComponent<water>().waterForceX;
			}
			
		}
	}*/
	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "water"){
			power.Remove(new Vector2(col.GetComponent<water>().waterForceX,col.GetComponent<water>().waterForceY));
			
			if(power.Count > 0){
				float highestX = 0;
				float highestY = 0;
				for(int i = 0; i<power.Count;i++){
					if(Mathf.Abs(power[i].x)>highestX){
						highestX = power[i].x;
					}
					if(Mathf.Abs(power[i].y)>highestY){
						highestY = power[i].y;
					}
				}
				waterForceX = highestX;
				waterForceY = highestY;
			}
			else{

				inWater = false;
				waterForceX = 0;
				waterForceY = 0;
				rb.drag = 0f;
			}
	
		}
		
	}
	
	public void Jump(){
		if(grounded){
			rb.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
				
		}
	}

}
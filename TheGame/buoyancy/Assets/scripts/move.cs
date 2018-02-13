using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour {

	public float speed = 2f;
	public float jump = 3f;
	public float radius = 1f;
	public float distance = 1f;
	bool grounded = false;
	//bool colliding = false;
	public float friction = 0.95f;
	public bool UseCustomFriction = true;
	public AudioClip[] JumpSound;
	public AudioClip[] whooosh;
	//public Color color1;
	//public Color color2;
	GameObject cameraa;
	AudioSource audioSource2;

	float leftrightinput;
	float waterForceX = 0f;
	float waterForceY = 0f;
	bool inWater;
	Rigidbody2D rb;
	List<Vector2> power = new List<Vector2>();
	GameObject lol;

	// Use this for initialization

	void Start () {
		cameraa = GameObject.Find("Main Camera");
		audioSource2 = cameraa.transform.GetChild(0).GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D>();
		if(Application.loadedLevel == 2 && !changeSceneOnline.tempo){
			lol = GameObject.Find("lol").GetComponent<Back>().online;
		}
	}
	
	void Update(){
		if(GameObject.Find("functions") != null){
			leftrightinput = GameObject.Find("functions").GetComponent<leftright>().leftorright;
		}

		
		//leftrightinput = GameObject.Find("Panel").GetComponent<leftrightcontrols>().leftrightcontrolinput;
		
		//if(inWater){
			groundcheck();
		//}
		
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
		if(grounded && UseCustomFriction){
			Vector2 vel = GetComponent<Rigidbody2D>().velocity;
			vel.x = vel.x * friction;
			rb.velocity = vel;
		}
		if(inWater){
			rb.AddForce(new Vector2(waterForceX,waterForceY)*25, ForceMode2D.Force);
		}

		
	}

	
	void groundcheck(){


		RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, radius, -Vector2.up, distance);
		if(hit.Length > 1){
			grounded = true;
		}
		else{
			grounded = false;
		}
		

	}
	/*void OnCollisionExit2D(Collision2D other){
		//colliding = false;
		if(!inWater){
			groundcheck();
		}
		
	}
	void OnCollisionStay2D(Collision2D other){
		print("hi");
		//colliding = true;
		groundcheck();
	}*/
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "water"){
			bool soundy = false;
			inWater = true;
			GetComponent<Rigidbody2D>().drag = 0.2f;
			power.Add(new Vector2(col.GetComponent<water>().waterForceX,col.GetComponent<water>().waterForceY));
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(waterForceX)){
				waterForceX = col.GetComponent<water>().waterForceX;
				soundy = true;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(waterForceY)){
				waterForceY = col.GetComponent<water>().waterForceY;
				soundy = true;
			}
			if(soundy){
				if(PlayerPrefs.GetInt("sound")==1){
					audioSource2.clip = whooosh[Random.Range(0,whooosh.Length-1)];
					audioSource2.Play();
				}
			}

			
		

			/*if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(waterForceY)){
				waterForceY = col.GetComponent<water>().waterForceY;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(waterForceX)){
				waterForceX = col.GetComponent<water>().waterForceX;
			}*/
			

			
		}
		if(col.tag == "goal" && !cameraa.GetComponent<inGoal>().inTheGoal){
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
					PlayerPrefs.SetInt("updated",0);
				}
			}
			else if(lol != null){
				lol.SetActive(true);

			}
			
			if(GameObject.Find("pause") && GameObject.Find("pause").GetComponent<openSomething>().openn == false){
				GameObject pausi = GameObject.Find("pause");
				pausi.GetComponent<openSomething>().open();
			}
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
				if(PlayerPrefs.GetInt("sound")==1){
					audioSource2.clip = whooosh[Random.Range(0,whooosh.Length-1)];
					audioSource2.Play();
				}
			}
	
		}
		
	}

	
	public void Jump(){
		if(grounded){
			rb.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
			if(PlayerPrefs.GetInt("sound")==1){
				cameraa.GetComponent<AudioSource>().clip = JumpSound[Random.Range(0,JumpSound.Length-1)];
				cameraa.GetComponent<AudioSource>().Play();
			}
			

		}
	}

}

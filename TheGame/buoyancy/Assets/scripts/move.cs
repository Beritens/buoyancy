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
	public float expectedTimestep = 0.02f;

	

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

		
		

		if(Input.GetButtonDown("Jump")){
			Jump();
			
		}
		
		
	}
	void FixedUpdate () {
		
		groundcheck();
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

			
		

			
			

			
		}
		if(col.tag == "goal" && !cameraa.GetComponent<inGoal>().inTheGoal){
			
			
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

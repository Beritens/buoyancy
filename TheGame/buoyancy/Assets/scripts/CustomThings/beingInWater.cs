using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beingInWater : MonoBehaviour {

	public float WaterForceX = 0;
	public float WaterForceY = 0;
	List<Vector2> power = new List<Vector2>();
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(WaterForceX,WaterForceY)*25, ForceMode2D.Force);
	}
	public void exit(Vector2 waterPower){
		power.Remove(waterPower);
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
			WaterForceX = highestX;
			WaterForceY = highestY;
		}
		else{
			
			GetComponent<Rigidbody2D>().drag = 0f;
			WaterForceX = 0;
			WaterForceY = 0;
			this.enabled = false;
		}

	}
	
}

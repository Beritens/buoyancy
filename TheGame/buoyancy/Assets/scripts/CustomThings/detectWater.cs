using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectWater : MonoBehaviour {

    List<Vector2> power = new List<Vector2>();
	public bool ok;

	void OnTriggerEnter2D(Collider2D col){
		if(ok && col.tag == "water"){
			bool soundy = false;
            
            beingInWater biw = GetComponent<beingInWater>();
            biw.enabled = true;
			GetComponent<Rigidbody2D>().drag = 0.2f;
			power.Add(new Vector2(col.GetComponent<water>().waterForceX,col.GetComponent<water>().waterForceY));
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(biw.WaterForceX)){
				biw.WaterForceX = col.GetComponent<water>().waterForceX;
				soundy = true;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(biw.WaterForceY)){
				biw.WaterForceY = col.GetComponent<water>().waterForceY;
				soundy = true;
			}

			
		

			/*if(Mathf.Abs(col.GetComponent<water>().waterForceY) > Mathf.Abs(waterForceY)){
				waterForceY = col.GetComponent<water>().waterForceY;
			}
			if(Mathf.Abs(col.GetComponent<water>().waterForceX) > Mathf.Abs(waterForceX)){
				waterForceX = col.GetComponent<water>().waterForceX;
			}*/
			

			
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
		if(ok && col.tag == "water"){
			power.Remove(new Vector2(col.GetComponent<water>().waterForceX,col.GetComponent<water>().waterForceY));
			beingInWater biw = GetComponent<beingInWater>();
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
				biw.WaterForceX = highestX;
				biw.WaterForceY = highestY;
			}
			else{
				biw.WaterForceX = 0;
				biw.WaterForceY = 0;
                biw.enabled = false;
				GetComponent<Rigidbody2D>().drag = 0f;
			}
	
		}
		
	}
}

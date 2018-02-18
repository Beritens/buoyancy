using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beingInWater : MonoBehaviour {

	public float WaterForceX = 0;
	public float WaterForceY = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(WaterForceX,WaterForceY)*25, ForceMode2D.Force);
	}
}

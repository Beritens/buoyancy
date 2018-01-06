using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour {

	public float ZoomSpeed;
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			if(GetComponent<Camera>().orthographicSize <=40){
				GetComponent<Camera>().orthographicSize++;
			}
			
		}
		else if(Input.GetAxis("Mouse ScrollWheel") > 0){
			if(GetComponent<Camera>().orthographicSize >=3){
				GetComponent<Camera>().orthographicSize--;
			}
			
		}
		
	}
}

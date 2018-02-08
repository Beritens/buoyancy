using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

	bool p = false;
	public void pausePlease () {
		p = !p;
		if(p){
			Time.timeScale = 0.05f;
		}
		else{
			Time.timeScale = 1;
		}
		
	}
}

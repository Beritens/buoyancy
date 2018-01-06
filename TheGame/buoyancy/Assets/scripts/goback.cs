using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class goback : MonoBehaviour {

	
	public UnityEvent eventi;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			print("lool");
			eventi.Invoke();

		}
	}
}

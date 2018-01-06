using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour {

	public GameObject thing;

	void Start(){
		Instantiate(thing, new Vector3(0,0,0), Quaternion.identity);
	}
}

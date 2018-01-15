using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour {

	public Transform cam;
	void Update () {
		transform.position = new Vector3(cam.position.x,transform.position.y,0);
	}
}

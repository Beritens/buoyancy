using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GameObject[] musics = GameObject.FindGameObjectsWithTag("music");
		if(musics.Length > 1){
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadMore : MonoBehaviour {

	loadPlayerLevels load;
	void Start () {
		load = GameObject.Find("loadPLayerLevelsButton").GetComponent<loadPlayerLevels>();
	}
	
	// Update is called once per frame
	public void press() {
		load.loadMore();
	}
}

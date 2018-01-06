using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour {

	void Awake () {
		Application.targetFrameRate = 60;
	}
}

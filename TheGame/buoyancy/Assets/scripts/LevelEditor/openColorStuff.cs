using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openColorStuff : MonoBehaviour {

	public GameObject color;
	public void press () {
		if(color.activeSelf && GameObject.Find("sizeStuff(Clone)")){
			color.GetComponent<COLOR>().change(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.GetComponent<SpriteRenderer>().color);
		}
	}
}

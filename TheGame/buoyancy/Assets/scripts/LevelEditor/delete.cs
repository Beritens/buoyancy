using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

	GameObject Scroller;

	void Start(){
		Scroller = GameObject.Find("Scroller");
	}
	public void press(){
		Scroller.GetComponent<scroll>().canIscroll2 = true;
		Scroller.GetComponent<scroll>().canIscroll = true;
		Scroller.GetComponent<undo>().add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, true, true);
		
		if(GameObject.Find("WaterPower")){
			GameObject.Find("WaterPowerOpen").GetComponent<openSomething>().close();
		}
		GameObject.Destroy(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject);
		GameObject.Destroy(GameObject.Find("sizeStuff(Clone)"));
		if(GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
			GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().closeTheMenu();
		}

	}
}

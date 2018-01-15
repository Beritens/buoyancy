using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

	GameObject Scroller;

	void Start(){
		Scroller = GameObject.Find("Scroller");
	}
	public void press(){
		GameObject thing =GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject;
		Scroller.GetComponent<scroll>().canIscroll2 = true;
		Scroller.GetComponent<scroll>().canIscroll = true;
		Scroller.GetComponent<undo>().add(thing, true, true);
		
		if(GameObject.Find("WaterPower")){
			GameObject.Find("WaterPowerOpen").GetComponent<openSomething>().close();
		}
		/*switch(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.tag){
			case "Player":
				Scroller.GetComponent<undo>().playerL.Remove(thing);
				break;
			case "ground":
				Scroller.GetComponent<undo>().groundL.Remove(thing);
				break;
			case "goal":
				Scroller.GetComponent<undo>().goalL.Remove(thing);
				break;
			case "obstacle":
				Scroller.GetComponent<undo>().obstacleL.Remove(thing);
				break;
			case "deko":
				Scroller.GetComponent<undo>().dekoL.Remove(thing);
				break;
			case "water":
				Scroller.GetComponent<undo>().waterL.Remove(thing);	
				break;
		}*/
		GameObject.Destroy(thing);
		GameObject.Destroy(GameObject.Find("sizeStuff(Clone)"));
		if(GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
			GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().closeTheMenu();
		}
		

	}
}

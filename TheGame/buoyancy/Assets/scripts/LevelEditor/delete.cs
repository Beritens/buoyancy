using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

	public GameObject Scroller;
	public openSomething water;
	public message message;
	public optionStuff optionStuff;
	//public createGroup createGroup;
	public void press(){
		if(!GameObject.Find("sizeStuff(Clone)"))
			return;
		GameObject thing =GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject;
		optionStuff.deselect();
		Scroller.GetComponent<scroll>().canIscroll2 = true;
		Scroller.GetComponent<scroll>().canIscroll = true;
		Scroller.GetComponent<undo>().add(thing, 0, true);
		/*if(thing.transform.parent != null){
			createGroup.ExitGroup();
		}*/
		
		if(water.gameObject.activeSelf){
			if(water.openn){
				water.close();
			}
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
		//thing.layer = 0;
		//thing.transform.Find("outline").gameObject.SetActive(false);
		thing.SetActive(false);
		message.Message("Object has been deleted");
		GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().deselect();
		if(GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
			GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().closeTheMenu();
		}
		

	}
}

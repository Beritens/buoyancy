using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour {

	// Use this for initialization
	public undo Undo;
	public message message;
	public void clicki () {
		if(GameObject.Find("sizeStuff(Clone)")){
			Transform ObjectToCopy = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
			GameObject copyObject = GameObject.Instantiate(ObjectToCopy.gameObject, ObjectToCopy.position, ObjectToCopy.rotation);
			
			
			print("halihallo");


			if(copyObject.tag == "deko"){
				int lol = GameObject.FindGameObjectsWithTag("deko").Length;
				
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,0f - lol* 0.001f);
					print("wieso funktioniert das jetzt nicht?");
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-1.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.dekoL.Count;
				Undo.dekoL++;
			}
			else if(copyObject.tag == "water"){
				int lol = GameObject.FindGameObjectsWithTag("water").Length;
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-1.5f - lol* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-3f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.waterL.Count;
				Undo.waterL++;
			}
			else if(copyObject.tag == "goal"){
				int lol = GameObject.FindGameObjectsWithTag("goal").Length;
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-3f - lol* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-4.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.goalL.Count;
				Undo.goalL++;
			}
			else if(copyObject.tag == "obstacle"){
				int lol = GameObject.FindGameObjectsWithTag("obstacle").Length;
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-4.5f - lol* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-6f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.obstacleL.Count;
				Undo.obstacleL++;
			}
			else if(copyObject.tag == "ground"){
				int lol = GameObject.FindGameObjectsWithTag("ground").Length;
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-6f - lol* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-7.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.groundL.Count;
				Undo.groundL++;
			}
			else if(copyObject.tag == "Player"){
				int lol = GameObject.FindGameObjectsWithTag("Player").Length;
				if(lol < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-7.5f - lol* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-9f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.playerL.Count;
				Undo.playerL++;
			}
			copyObject.name = ObjectToCopy.name;
			copyObject.GetComponent<Draggable>().ObjectLPos = Undo.allThings.Count;
			Undo.allThings.Add(copyObject);
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(copyObject.transform);
			message.Message("Object has been copied");
			Undo.add(copyObject, 0, true);
			
			
		}
	}
}

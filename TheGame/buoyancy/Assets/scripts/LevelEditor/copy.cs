using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour {

	// Use this for initialization
	public undo Undo;
	public void clicki () {
		if(GameObject.Find("sizeStuff(Clone)")){
			Transform ObjectToCopy = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
			GameObject copyObject = GameObject.Instantiate(ObjectToCopy.gameObject, ObjectToCopy.position, ObjectToCopy.rotation);
			
			
			print("halihallo");


			if(copyObject.tag == "deko"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("deko");
				
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,0f - lol.Length* 0.001f);
					print("wieso funktioniert das jetzt nicht?");
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-1.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.dekoL.Count;
				Undo.dekoL++;
			}
			else if(copyObject.tag == "water"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("water");
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-1.5f - lol.Length* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-3f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.waterL.Count;
				Undo.waterL++;
			}
			else if(copyObject.tag == "goal"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("goal");
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-3f - lol.Length* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-4.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.goalL.Count;
				Undo.goalL++;
			}
			else if(copyObject.tag == "obstacle"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("obstacle");
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-4.5f - lol.Length* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-6f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.obstacleL.Count;
				Undo.obstacleL++;
			}
			else if(copyObject.tag == "ground"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("ground");
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-6f - lol.Length* 0.001f);
				}
				else{
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-7.5f);
				}
				//copyObject.GetComponent<Draggable>().ObjectLPos = Undo.groundL.Count;
				Undo.groundL++;
			}
			else if(copyObject.tag == "Player"){
				GameObject[] lol = GameObject.FindGameObjectsWithTag("Player");
				if(lol.Length < 1500){
					copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,-7.5f - lol.Length* 0.001f);
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
			Undo.add(copyObject, 0, true);
			
			
		}
	}
}

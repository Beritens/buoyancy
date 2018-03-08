using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour {

	// Use this for initialization
	public undo Undo;
	public message message;
	public optionStuff optionStuff;
	public void clicki () {
		if(GameObject.Find("sizeStuff(Clone)")){
			Transform ObjectToCopy = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
			GameObject copyObject = GameObject.Instantiate(ObjectToCopy.gameObject, new Vector3(ObjectToCopy.transform.position.x,ObjectToCopy.transform.position.y,Mathf.Clamp(ObjectToCopy.transform.position.z-0.001f,-10,0)), ObjectToCopy.rotation);
			if(ObjectToCopy.transform.parent != null){
				copyObject.transform.parent = ObjectToCopy.transform.parent;
				copyObject.transform.localScale = ObjectToCopy.transform.localScale;
			}
			
			optionStuff.select(copyObject);


			if(copyObject.tag == "deko"){
				
				Undo.dekoL++;
			}
			else if(copyObject.tag == "water"){
				
				Undo.waterL++;
			}
			else if(copyObject.tag == "goal"){
				
				Undo.goalL++;
			}
			else if(copyObject.tag == "obstacle"){
				
				Undo.obstacleL++;
			}
			else if(copyObject.tag == "ground"){
				
				Undo.groundL++;
			}
			else if(copyObject.tag == "Player"){
				
				Undo.playerL++;
			}			
			//copyObject.transform.position = new Vector3(copyObject.transform.position.x,copyObject.transform.position.y,Mathf.Clamp(copyObject.transform.position.z-0.001f,0,-10));
			copyObject.name = ObjectToCopy.name;
			copyObject.GetComponent<Draggable>().ObjectLPos = Undo.allThings.Count;
			Undo.allThings.Add(copyObject);
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(copyObject.transform);
			message.Message("Object has been copied");
			Undo.add(copyObject, 0, true);
			
			
		}
	}
}

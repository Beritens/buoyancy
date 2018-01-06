using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	
	GameObject Scroller;
	public GameObject thing;
	public bool player;
	public bool ground;
	public bool water;
	public bool obstacle;
	public bool goal;
	public bool deko;
	undo Undo;
	void Start(){
		Scroller = GameObject.Find("Scroller");
		Undo = Scroller.GetComponent<undo>();
	}
	public void spawnDaThing(){
		if(Input.touchCount ==1 && !GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen){
			Touch touch = Input.GetTouch(0);
			GameObject bob = GameObject.Instantiate(thing,Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10)),Quaternion.identity);
			bob.GetComponent<Draggable>().ok = true;
			Scroller.GetComponent<scroll>().canIscroll = false;
			

			//Position
			if(deko){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("deko");
				if(Undo.dekoL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,0f - Undo.dekoL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-1.5f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.dekoL.Count;
				Undo.dekoL.Add(bob);
				
				//bob.GetComponent<SpriteRenderer>().sortingOrder = Undo.x.Count -1;
			}
			else if(water){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("water");
				if(Undo.waterL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-1.5f - Undo.waterL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-3f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.waterL.Count;
				Undo.waterL.Add(bob);
				
			}
			else if(goal){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("goal");
				if(Undo.goalL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-3f - Undo.goalL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-4.5f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.goalL.Count;
				Undo.goalL.Add(bob);
				
			}
			else if(obstacle){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("obstacle");
				if(Undo.obstacleL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-4.5f - Undo.obstacleL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-6f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.obstacleL.Count;
				Undo.obstacleL.Add(bob);
				
			}
			else if(ground){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("ground");
				if(Undo.groundL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-6f - Undo.groundL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-7.5f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.groundL.Count;
				Undo.groundL.Add(bob);
				
			}
			else if(player){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("Player");
				if(Undo.playerL.Count < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-7.5f - Undo.playerL.Count* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-9f);
				}
				bob.GetComponent<Draggable>().ObjectLPos = Undo.playerL.Count;
				Undo.playerL.Add(bob);
				
			}




			if(GameObject.Find("sizeStuff(Clone)")){
				GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject.layer = 0;
				if(GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().opeeen){
					GameObject.Find("PleaseOpenTheMenu").GetComponent<open>().closeTheMenu();
				}
				
				if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline")){
					GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline").gameObject.SetActive(false);
				}
				
				GameObject sizeStuff = GameObject.Find("sizeStuff(Clone)");
				
				GameObject.Destroy(sizeStuff);

				
			}
		}
		
	}
}

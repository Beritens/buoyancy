using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	
	public GameObject Scroller;
	public GameObject thing;
	public bool player;
	public bool ground;
	public bool water;
	public bool obstacle;
	public bool goal;
	public bool deko;
	public changeShape shapee;
	public open openMenu;
	public optionStuff optionStuff;
	undo Undo;
	public createGroup createGroup;
	void Start(){
		Undo = Scroller.GetComponent<undo>();
	}
	public void spawnDaThing(){
		if(Input.touchCount ==1 && !GameObject.Find("Scroller").GetComponent<isSomethingOpen>().SomethingOpen){
			Touch touch = Input.GetTouch(0);
			GameObject bob = GameObject.Instantiate(thing,Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,10)),Quaternion.identity);
			bob.GetComponent<Draggable>().ok = true;
			Scroller.GetComponent<scroll>().canIscroll = false;
			
			if(createGroup.editing == true){
				bob.transform.parent = createGroup.groupy;
				bob.GetComponent<SpriteRenderer>().sortingOrder = 9;
			}
			//Position
			if(deko){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("deko");
				if(Undo.dekoL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,0f - Undo.dekoL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-1.5f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.dekoL.Count;
				Undo.dekoL++;
				
				//bob.GetComponent<SpriteRenderer>().sortingOrder = Undo.x.Count -1;
			}
			else if(water){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("water");
				if(Undo.waterL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-1.5f - Undo.waterL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-3f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.waterL.Count;
				Undo.waterL++;
				
			}
			else if(goal){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("goal");
				if(Undo.goalL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-3f - Undo.goalL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-4.5f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.goalL.Count;
				Undo.goalL++;
				
			}
			else if(obstacle){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("obstacle");
				if(Undo.obstacleL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-4.5f - Undo.obstacleL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-6f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.obstacleL.Count;
				Undo.obstacleL++;
				
			}
			else if(ground){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("ground");
				if(Undo.groundL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-6f - Undo.groundL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-7.5f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.groundL.Count;
				Undo.groundL++;
				
			}
			else if(player){
				//GameObject[] lol = GameObject.FindGameObjectsWithTag("Player");
				if(Undo.playerL < 1500){
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-7.5f - Undo.playerL* 0.001f);
				}
				else{
					bob.transform.position = new Vector3(bob.transform.position.x,bob.transform.position.y,-9f);
				}
				//bob.GetComponent<Draggable>().ObjectLPos = Undo.playerL.Count;
				Undo.playerL++;
				
			}
			int shape = shapee.shape;
			switch(shape){
				case 0:
					
					bob.GetComponent<BoxCollider2D>().enabled = true;
					break;
				case 1:
					if(bob.tag == "Player"){
						bob.GetComponent<CircleCollider2D>().enabled = true;
					}
					else{
						bob.GetComponents<PolygonCollider2D>()[2].enabled = true;
					}
					break;
				case 2:
					bob.GetComponents<PolygonCollider2D>()[1].enabled = true;
					break;
				case 3:
					bob.GetComponents<PolygonCollider2D>()[0].enabled = true;
					break;
			}
			
			bob.GetComponent<SpriteRenderer>().sprite = shapee.shapes[shape];
			bob.GetComponent<Draggable>().Shape = shape;

			bob.GetComponent<Draggable>().ObjectLPos = Undo.allThings.Count;
			Undo.allThings.Add(bob);
			




			/*if(GameObject.Find("sizeStuff(Clone)")){
				optionStuff.deselect();
				GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject.layer = 0;
				if(openMenu.opeeen){
					openMenu.closeTheMenu();
				}
				
				if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline")){
					GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.Find("outline").gameObject.SetActive(false);
				}
				
				GameObject sizeStuff = GameObject.Find("sizeStuff(Clone)");
				
				GameObject.Destroy(sizeStuff);

				
			}*/
		}
		
	}
}

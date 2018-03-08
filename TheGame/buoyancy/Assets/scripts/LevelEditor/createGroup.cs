using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class createGroup : MonoBehaviour {

	public GameObject group;
	public undo undo;
	public TextMeshProUGUI textMesh;
	public int state;
	public bool editing = false;
	public Transform groupy;
	public optionStuff optionStuff;
	public GameObject darkThing;
	public GameObject sizeThing;
	public sizeThing sizeStuff;
	public open openMenu;

	public void click(){
		if(state == 0){
			makeGroup();
		}
		else if(state == 1){
			if(sizeStuff == null){
				sizeStuff = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
			}
			EditGroup(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square);
		}
		else if(state == 2){
			ExitGroup();
		}
	}

	public void makeGroup () {
		if(GameObject.Find("sizeStuff(Clone)")){
			if(sizeStuff == null){
				sizeStuff = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
			}
			Transform square = sizeStuff.square;
			if(square.parent == null){
				GameObject bob = GameObject.Instantiate(group,square.position,Quaternion.identity);
				bob.GetComponent<Draggable>().ObjectLPos = undo.allThings.Count;
				undo.allThings.Add(bob);
				square.parent = bob.transform;
				sizeStuff.reselect(bob.transform);
				optionStuff.select(bob);
				EditGroup(bob.transform);
				undo.add(square.gameObject,14,true);
			}
			
		}
		
	}
	public void select(){
		editing = false;
		state = 1;
		darkThingOff();
		textMesh.text = "edit Group";
	}
	public void darkThingOn(){
		darkThing.SetActive(true);
		if(groupy != null){
			for(int i = 5;i<groupy.childCount;i++){
				groupy.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 9;
			}
		}
		
	}
	public void darkThingOff(){
		darkThing.SetActive(false);
		if(groupy != null){
			for(int i = 5;i<groupy.childCount;i++){
				groupy.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder = 0;
			}
		}
		
	}

	public void ExitGroup(){
		editing = false;
		state = 1;
		darkThingOff();
		if(sizeStuff == null && GameObject.Find("sizeStuff(Clone)")){
			sizeStuff = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>();
		}

		if(sizeStuff != null){
			sizeStuff.reselect(groupy);
		}
		else{
			GameObject sizeStuffy = GameObject.Instantiate(sizeThing,transform.position,Quaternion.identity);
			groupy.GetComponent<BoxCollider2D>().enabled = true;
			sizeStuffy.GetComponent<sizeThing>().square = groupy.transform;
			sizeStuff = sizeStuffy.GetComponent<sizeThing>();
			//groupy.Find("outline").gameObject.SetActive(true);
			groupy.gameObject.layer = 8;
		}
		openMenu.openTheMenu();
		optionStuff.select(groupy.gameObject);
		textMesh.text = "edit Group";
	}
	public void EditGroup(Transform square){
		if(square.parent != null){
			groupy = square.parent;
		}
		else{
			groupy = square;
		}
		editing = true;
		darkThingOn();
		state = 2;
		if(sizeStuff != null){
			openMenu.closeTheMenu();
			sizeStuff.deselect();
			optionStuff.deselect();
		}
		textMesh.text = "exit Group";
	}
}

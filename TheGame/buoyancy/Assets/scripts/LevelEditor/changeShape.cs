﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeShape : MonoBehaviour {

	
	public Sprite[] shapes;
	public Image[] buttons;
	public undo undo;
	public int shape = 0;
	public optionStuff optionStuff;
	public void click(){
		shape++;
		if(shape >= shapes.Length){

			shape = 0;
			
		}
		//GetComponent<Image>().sprite = shapes[shape];
		for(int i = 0; i<buttons.Length; i++){
			
			buttons[i].sprite=shapes[shape];
		}
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject thing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject;
			if(thing.tag != "group"){
				thing.GetComponent<SpriteRenderer>().sprite = shapes[shape];
				switch(thing.GetComponent<Draggable>().Shape){
					/*case 0:
						thing.GetComponent<BoxCollider2D>().enabled = false;
						break;*/
					case 1:
						if(thing.tag == "Player"){
							thing.GetComponent<CircleCollider2D>().enabled = false;
						}
						else{
							thing.GetComponents<PolygonCollider2D>()[2].enabled = false;
						}
						break;
					case 2:
						thing.GetComponents<PolygonCollider2D>()[1].enabled = false;
						break;
					case 3:
						thing.GetComponents<PolygonCollider2D>()[0].enabled = false;
						break;
				}
				switch(shape){
					case 0:
						thing.GetComponent<BoxCollider2D>().enabled = true;
						break;
					case 1:
						if(thing.tag == "Player"){
							thing.GetComponent<CircleCollider2D>().enabled = true;
						}
						else{
							thing.GetComponents<PolygonCollider2D>()[2].enabled = true;
						}
						break;
					case 2:
						thing.GetComponents<PolygonCollider2D>()[1].enabled = true;
						break;
					case 3:
						thing.GetComponents<PolygonCollider2D>()[0].enabled = true;
						break;
				}
				optionStuff.changeTheShape();
				undo.add(thing, 9, true);
				thing.GetComponent<Draggable>().Shape = shape;
				undo.add(thing, 9, false);
			}
			
		}

	}
	public void onlyChangeObject(GameObject obj){
		Draggable drag =obj.GetComponent<Draggable>();
		switch(obj.GetComponent<Draggable>().Shape){
			/*case 0:
				obj.GetComponent<BoxCollider2D>().enabled = false;
				break;*/
			case 1:
				if(obj.tag == "Player"){
					obj.GetComponent<CircleCollider2D>().enabled = false;
				}
				else{
					obj.GetComponents<PolygonCollider2D>()[2].enabled = false;
				}
				break;
			case 2:
				obj.GetComponents<PolygonCollider2D>()[1].enabled = false;
				break;
			case 3:
				obj.GetComponents<PolygonCollider2D>()[0].enabled = false;
				break;
		}
		undo.add(obj, 9, true);
		drag.Shape++;
		if(drag.Shape >= shapes.Length){
			drag.Shape = 0;
		}
		obj.GetComponent<SpriteRenderer>().sprite = shapes[drag.Shape];
		
		switch(obj.GetComponent<Draggable>().Shape){
			case 0:
				obj.GetComponent<BoxCollider2D>().enabled = true;
				break;
			case 1:
				if(obj.tag == "Player"){
					obj.GetComponent<CircleCollider2D>().enabled = true;
				}
				else{
					obj.GetComponents<PolygonCollider2D>()[2].enabled = true;
				}
				break;
			case 2:
				obj.GetComponents<PolygonCollider2D>()[1].enabled = true;
				break;
			case 3:
				obj.GetComponents<PolygonCollider2D>()[0].enabled = true;
				break;
		}
		
		undo.add(obj, 9, false);	
	}
}

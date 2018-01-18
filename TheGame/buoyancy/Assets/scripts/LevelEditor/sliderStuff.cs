using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderStuff : MonoBehaviour {

	public bool tueEs;
	public Transform knob;
	public float value;
	public undo Undo;
	public COLOR colory;
	public bool hue;
	public void down () {
		
		tueEs = true;
		if(hue && colory.bg1on){
			Undo.add(null, 5, true);
		}
		else if(hue && colory.bg2on){
			Undo.add(null, 6, true);
		}
		else if(GameObject.Find("sizeStuff(Clone)")){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, 4, true);
		}
	}
	public void up () {
		tueEs = false;
		if(hue && colory.bg1on){
			Undo.add(null, 5, false);
		}
		else if(hue && colory.bg2on){
			Undo.add(null, 6, false);
		}
		if(GameObject.Find("sizeStuff(Clone)")){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, 4, false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(tueEs){
			if(Input.touchCount == 1){
				Touch touch = Input.GetTouch(0);

				knob.position = new Vector3(knob.position.x, Mathf.Clamp(touch.position.y,transform.position.y-(GetComponent<RectTransform>().rect.size.y/2),transform.position.y+(GetComponent<RectTransform>().rect.size.y/2)));
				value = (knob.position.y-(transform.position.y-GetComponent<RectTransform>().rect.size.y/2))/GetComponent<RectTransform>().rect.size.y;
			}
		}
	}
	public void changePos(float f){
		value = f;
		knob.position = new Vector3(knob.position.x, ((transform.position.y-GetComponent<RectTransform>().rect.size.y/2))+f*GetComponent<RectTransform>().rect.size.y,0);
	}
}

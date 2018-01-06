using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaterStuffInput : MonoBehaviour {

	public TMP_InputField vertical;
	public TMP_InputField horizontal;
	public water water;
	public Color colori;
	public undo Undo;

	public void changeText(){
		float vert = 1;
		float hori = 0;
		if(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.GetComponent<water>() != null){
			water = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.GetComponent<water>();
			vert = water.waterForceY;
			hori = water.waterForceX;
		}
		
		vertical.text = vert.ToString();
		horizontal.text = hori.ToString();
		
	}
	void Start(){
		

		var se = new TMP_InputField.SubmitEvent();
		
		vertical.onEndEdit.AddListener(Submit);
		horizontal.onEndEdit.AddListener(Submit2);
	}
	private void Submit(string a){
		if(water != null){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
			if(a.Length > 0){
				water.waterForceY = float.Parse(a);
				print(a);
			}
			else{
				water.waterForceY = 0;
			}
			if(!water.colorChanged){
				color();
			}
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
		}

	}
	private void Submit2(string a){
		if(water != null){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
			if(a.Length > 0){
				water.waterForceX = float.Parse(a);
				print(a);
			}
			else{
				water.waterForceX = 0;
			}
			if(!water.colorChanged){
				color();
			}
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
			
		}
	}
	void color(){
		float X = water.waterForceX;
		float Y = water.waterForceY;
		var angle = (150 - (Mathf.Atan2(0 - Y, 0 - X)) * 180 / Mathf.PI)/360;
		print(angle + "angle");
		float h,s,v;
		Color.RGBToHSV(colori,out h, out s, out v);
		Color col = Color.HSVToRGB(angle,s,v);
		float alpha = Mathf.Clamp(Mathf.Sqrt(X*X+Y*Y)*0.27f,0.1f,0.9f);
		col.a = alpha;
		water.GetComponent<SpriteRenderer>().color = col;
		COLOR colorComponent = GameObject.Find("color picker").GetComponent<COLOR>();
		colorComponent.hue.changePos(angle);
		colorComponent.h = angle;
		colorComponent.s = s;
		colorComponent.v = v;
		colorComponent.alpha.changePos(alpha);
		colorComponent.a = alpha;
		colorComponent.color = col;
		colorComponent.alphaSlider.color = new Color(col.r,col.g,col.b,1);
		GameObject.Find("color picker").GetComponent<Image>().color = Color.HSVToRGB(angle,1,1);

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class COLOR : MonoBehaviour {

	bool on;
	public bool bg1on;
	public bool bg2on;
	public Image bg1;
	public Image bg2;
	public FarbenLager cam;
	public bool eyeDropper;
	public Color color;
	public sliderStuff hue;
	public sliderStuff alpha;
	public Image alphaSlider;
	public Image preview;
	public float h;
	public float s;
	public float v;
	public float a;
	public Image dropper;
	public Sprite dropperAn;
	public Sprite dropperAus;
	public Transform circle;
	public undo Undo;
	public GameObject Scroller;
	public optionStuff optionStuff;
	void Start () {
		
	}
	
	// Update is called once per frame
	public void change(Color col, bool eye){
		float ha, sa, va;
		Color.RGBToHSV(col, out ha, out sa, out va);
		preview.color = col;
		hue.changePos(ha);
		h = ha;
		s = sa;
		v = va;
		alpha.changePos(col.a);
		a = col.a;
		color = col;
		alphaSlider.color = new Color(col.r,col.g,col.b,1);
		GetComponent<Image>().color = Color.HSVToRGB(h,1,1);
		circle.position = new Vector2(s*GetComponent<RectTransform>().rect.size.x+transform.position.x-GetComponent<RectTransform>().rect.size.x/2, v*GetComponent<RectTransform>().rect.size.y+transform.position.y-GetComponent<RectTransform>().rect.size.y/2);
		if(eye){
			if(!bg1on && !bg2on && GameObject.Find("sizeStuff(Clone)")){
				Transform square = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
				if(square.tag != "group"){
					Scroller.GetComponent<undo>().add(square.gameObject, 4, true);
				
					square.GetComponent<SpriteRenderer>().color = color;
					optionStuff.changeColor(color);
					if(square.tag == "water"){
						square.GetComponent<water>().colorChanged = true;
					}
					isSomethingOpen.modified = true;
					Scroller.GetComponent<undo>().add(square.gameObject, 4, false);
				}
				
			}
			else if(bg1on){
				isSomethingOpen.modified = true;
				Scroller.GetComponent<undo>().add(null, 5, true);
				Color c = new Color(color.r,color.g,color.b,1);
				bg1.color =  c;
				cam.bg1 = c;
				cam.GetComponent<Camera>().backgroundColor = c;
				Scroller.GetComponent<undo>().add(null, 5, false);
			}
			else if(bg2on){

				isSomethingOpen.modified = true;
				Scroller.GetComponent<undo>().add(null, 6, true);
				Color c = new Color(color.r,color.g,color.b,1);
				bg2.color =  c;
				cam.bg2 = c;
				Scroller.GetComponent<undo>().add(null, 6, false);
			}
		}
	}
	void Update () {
		if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);

			if(on){
				circle.position = new Vector2(Mathf.Clamp(touch.position.x, transform.position.x-GetComponent<RectTransform>().rect.size.x/2, transform.position.x+GetComponent<RectTransform>().rect.size.x/2), Mathf.Clamp(touch.position.y, transform.position.y-GetComponent<RectTransform>().rect.size.y/2, transform.position.y+GetComponent<RectTransform>().rect.size.y/2));
				//print(GetComponent<RectTransform>().rect.size);
				Vector2 screenPos = new Vector2(touch.position.x-transform.position.x,touch.position.y-transform.position.y)/GetComponent<RectTransform>().rect.size.x;
				//colorStuff.GetComponent<Image>().color = new Color(0.1f,0.8f,0.5f,1);
				float x = screenPos.x+0.5f;
				float y = screenPos.y+0.5f;

				
				
				h = hue.value;
				s = Mathf.Clamp(x,0,1);
				v = Mathf.Clamp(y,0,1);
				a = alpha.value;
				color = Color.HSVToRGB(h,s,v);
				preview.color = new Color(color.r,color.g,color.b,a);
				alphaSlider.color = new Color(color.r,color.g,color.b,1);
				if(bg1on){
					Color c = new Color(color.r,color.g,color.b,1);
					bg1.color =  c;
					cam.bg1 = c;
					cam.GetComponent<Camera>().backgroundColor = c;
				}
				if(bg2on){
					Color c = new Color(color.r,color.g,color.b,1);
					bg2.color =  c;
					cam.bg2 = c;
				}
				
			}
			if(hue.tueEs){
				
				h = hue.value;
				color = Color.HSVToRGB(h,s,v);
				GetComponent<Image>().color = Color.HSVToRGB(h,1,1);
				preview.color = new Color(color.r,color.g,color.b,a);
				alphaSlider.color = new Color(color.r,color.g,color.b,1);
				if(bg1on){
					Color c = new Color(color.r,color.g,color.b,1);
					bg1.color =  c;
					cam.bg1 = c;
					cam.GetComponent<Camera>().backgroundColor = c;
				}
				if(bg2on){
					Color c = new Color(color.r,color.g,color.b,1);
					bg2.color =  c;
					cam.bg2 = c;
				}
			}
			if(alpha.tueEs){
				a = alpha.value;
				preview.color = new Color(color.r,color.g,color.b,a);
			}
			if(GameObject.Find("sizeStuff(Clone)") && (on || alpha.tueEs || hue.tueEs) && !bg1on && !bg2on){
				Color endColor = new Color(color.r,color.g,color.b,a);
				
				Transform thing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
				if(thing.tag != "group"){
					thing.GetComponent<SpriteRenderer>().color = endColor;
					optionStuff.changeColor(endColor);
					isSomethingOpen.modified = true;
					if(thing.tag == "water"){
						print("dasHier");
						thing.GetComponent<water>().colorChanged = true;
					}
				}
				
			}
			/*if(touch.phase == TouchPhase.Ended && on){

			}*/
			 
		}
		
	}
	public void DOWN(){
		on = true;
		if(GameObject.Find("sizeStuff(Clone)") && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.tag != "group" && !bg1on && !bg2on){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject,4, true);
		}
		else if(bg1on){
			Scroller.GetComponent<undo>().add(null, 5, true);
		}
		else if(bg2on){
			Scroller.GetComponent<undo>().add(null, 6, true);
		}
	}
	public void UP(){
		on = false;
		if(GameObject.Find("sizeStuff(Clone)") && GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.tag != "group" && !bg1on && !bg2on){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject,4, false);
		}
		else if(bg1on){
			Scroller.GetComponent<undo>().add(null, 5, false);
		}
		else if(bg2on){
			Scroller.GetComponent<undo>().add(null, 6, false);
		}
	}
	
	public void EYEDROPPER(){
		eyeDropper = !eyeDropper;
		if(eyeDropper){
			dropper.sprite = dropperAn;
		}
		else{
			dropper.sprite = dropperAus;
		}
		
	}
	public void BG1(){
		bg1on = !bg1on;
		if(bg1on){
			change(bg1.color, false);
			bg2on = false;
			bg2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
			bg1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,1);
		}
		else{
			bg1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
		}
		
	}
	public void BG2(){
		bg2on = !bg2on;
		if(bg2on){
			change(bg2.color, false);
			bg1on = false;
			bg1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
			bg2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,1);
		}
		else{
			bg2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
		}
		
	}
	public void bgsOff(){
		bg1on = false;
		bg1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
		bg2on = false;
		bg2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f);
	}
	public void eyeOff(){
		eyeDropper = false;
		dropper.sprite = dropperAus;
	}

}

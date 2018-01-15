using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class COLOR : MonoBehaviour {

	bool on;
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
	void Start () {
		
	}
	
	// Update is called once per frame
	public void change(Color col){
		float ha, sa, va;
		Color.RGBToHSV(col, out ha, out sa, out va);
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
						
				
			}
			if(hue.tueEs){
				h = hue.value;
				color = Color.HSVToRGB(h,s,v);
				GetComponent<Image>().color = Color.HSVToRGB(h,1,1);
				preview.color = new Color(color.r,color.g,color.b,a);
				alphaSlider.color = new Color(color.r,color.g,color.b,1);
			}
			if(alpha.tueEs){
				a = alpha.value;
				preview.color = new Color(color.r,color.g,color.b,a);
			}
			if(GameObject.Find("sizeStuff(Clone)") && (on || alpha.tueEs || hue.tueEs)){
				Transform thing = GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square;
				thing.GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,a);
				isSomethingOpen.modified = true;
				if(thing.tag == "water"){
					thing.GetComponent<water>().colorChanged = true;
				}
			}
			/*if(touch.phase == TouchPhase.Ended && on){

			}*/
			 
		}
		
	}
	public void DOWN(){
		on = true;
		if(GameObject.Find("sizeStuff(Clone)")){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, true);
		}
	}
	public void UP(){
		on = false;
		if(GameObject.Find("sizeStuff(Clone)")){
			Undo.add(GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().square.gameObject, false, false);
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

}

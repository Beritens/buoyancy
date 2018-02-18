using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class optionStuff : MonoBehaviour {

	public GameObject delete;
	public GameObject copy;
	public undo undo;
	public changeShape changeShape;
	public Sprite falling;
	public Sprite notFalling;
	public bool on = false;
	public GameObject backgroundStuff;
	public GameObject allOptions;
	public TextMeshProUGUI type;
	public GameObject scale;
	public RectTransform rotation;
	public GameObject appeareance;
	public GameObject flow;
	public GameObject physics1;
	public GameObject physics2;

	public TMP_InputField px;
	public TMP_InputField py;
	public TMP_InputField pz;
	public TMP_InputField sx;
	public TMP_InputField sy;
	public TMP_InputField rot;
	public TMP_InputField fx;
	public TMP_InputField fy;
	public TMP_InputField b1;
	public TMP_InputField b2;
	public Image fallingStuff;
	public Image shape;
	public Image colorButton;
	public GameObject editObj = null;
	public COLOR colorComponent;
	public Color colori;
	
	void Start () {
		px.onEndEdit.AddListener(pxS);
		py.onEndEdit.AddListener(pyS);
		pz.onEndEdit.AddListener(pzS);
		sx.onEndEdit.AddListener(sxS);
		sy.onEndEdit.AddListener(syS);
		rot.onEndEdit.AddListener(rotS);
		fx.onEndEdit.AddListener(fxS);
		fy.onEndEdit.AddListener(fyS);
		b1.onEndEdit.AddListener(bS);
		b2.onEndEdit.AddListener(bS);
	}
	public void select(GameObject obj){
		editObj = obj;
		if(on){
			allOptions.SetActive(true);
			backgroundStuff.SetActive(false);
			delete.SetActive(true);
			copy.SetActive(true);
			doStuff();
		}
		
	}
	public void deselect(){
		allOptions.SetActive(false);
		backgroundStuff.SetActive(true);
		delete.SetActive(false);
		copy.SetActive(false);
		type.text = "world";
	}
	public void open(){
		on = true;
		if(editObj != null){
			delete.SetActive(true);
			copy.SetActive(true);
			allOptions.SetActive(true);
			backgroundStuff.SetActive(false);
			doStuff();
		}
		else{
			allOptions.SetActive(false);
			backgroundStuff.SetActive(true);
			delete.SetActive(false);
			copy.SetActive(false);
			type.text = "world";
		}
	}
	void doStuff(){
		if(editObj.tag == "deko"){
			type.text = "decoration";
		}
		else{
			type.text = editObj.tag;
		}
		colorButton.color = editObj.GetComponent<SpriteRenderer>().color;
		Transform trans = editObj.transform;
		px.text = trans.position.x.ToString("0.###");
		py.text = trans.position.y.ToString("0.###");
		pz.text = (-trans.position.z).ToString("0.###");
		rot.text = trans.rotation.eulerAngles.z.ToString("0.###");
		shape.sprite = changeShape.shapes[editObj.GetComponent<Draggable>().Shape];
		if(editObj.tag == "Player"){
			scale.SetActive(false);
			flow.SetActive(false);
			physics1.SetActive(false);
			physics2.SetActive(true);
			appeareance.GetComponent<RectTransform>().anchorMax = new Vector2(1,0.6f);
			appeareance.GetComponent<RectTransform>().anchorMin = new Vector2(0,0.4f);
			rotation.anchorMax = new Vector2(1,0.8f);
			rotation.anchorMin = new Vector2(0,0.6f);
			b2.text = (editObj.GetComponent<Draggable>().bounciness*100).ToString("0.###");

		}
		else{
			scale.SetActive(true);
			physics2.SetActive(false);
			rotation.anchorMax = new Vector2(1,0.6f);
			rotation.anchorMin = new Vector2(0,0.4f);
			appeareance.GetComponent<RectTransform>().anchorMax = new Vector2(1,0.4f);
			appeareance.GetComponent<RectTransform>().anchorMin = new Vector2(0,0.2f);
			sx.text = (trans.localScale.x/50).ToString("0.###");
			sy.text = (trans.localScale.y/50).ToString("0.###");
			if(editObj.tag == "water"){
				flow.SetActive(true);
				physics1.SetActive(false);
				water water = editObj.GetComponent<water>();
				fx.text = water.waterForceX.ToString("0.####");
				fy.text = water.waterForceY.ToString("0.####");
			}
			else if(editObj.tag == "obstacle" || editObj.tag == "ground"){
				flow.SetActive(false);
				physics1.SetActive(true);
				b1.text = (editObj.GetComponent<Draggable>().bounciness*100).ToString("0.###");
				if(editObj.GetComponent<Draggable>().falling){
					fallingStuff.sprite = falling;
				}
				else{
					fallingStuff.sprite = notFalling;
				}
				
			}
			else{
				physics1.SetActive(false);
				flow.SetActive(false);
			}
		}
		
		
	}
	public void doShapeStuff(){
		changeShape.onlyChangeObject(editObj);
		shape.sprite = changeShape.shapes[editObj.GetComponent<Draggable>().Shape];
	}
	public void fallingOnOff(){
		undo.add(editObj,12,true);
		Draggable draggy = editObj.GetComponent<Draggable>();
		draggy.falling = !draggy.falling;
		if(draggy.falling){
			fallingStuff.sprite = falling;
		}
		else{
			fallingStuff.sprite = notFalling;
		}
		undo.add(editObj,12,false);
	}
	public void changeTheShape(){
		if(on){
			shape.sprite = changeShape.shapes[editObj.GetComponent<Draggable>().Shape];
		}
	}
	public void changePosition(){
		if(on){
			px.text = editObj.transform.position.x.ToString("0.###");
			py.text = editObj.transform.position.y.ToString("0.###");
			pz.text = (-editObj.transform.position.z).ToString("0.###");
		}
		
	}
	public void changeScale(){
		if(on){
			sx.text = (editObj.transform.localScale.x/50).ToString("0.###");
			sy.text = (editObj.transform.localScale.y/50).ToString("0.###");
		}
		
	}
	public void changeColor(Color color){
		if(on){
			colorButton.color = color;
		}
	}
	public void changeRotation(){
		if(on){
			rot.text = editObj.transform.rotation.eulerAngles.z.ToString("0.###");
		}
		
	}
	public void changeFalling(){
		if(on){
			if(editObj.GetComponent<Draggable>().falling){
				fallingStuff.sprite = falling;
			}
			else{
				fallingStuff.sprite = notFalling;
			}
		}
	}
	public void changeBounciness(){
		if(on){
			b1.text = (editObj.GetComponent<Draggable>().bounciness*100).ToString("0.###");
			b2.text = (editObj.GetComponent<Draggable>().bounciness*100).ToString("0.###");
		}
	}
	public void changeWaterX(){
		if(on && editObj.tag == "water"){
			fx.text = editObj.GetComponent<water>().waterForceX.ToString("0.####");
		}
	}
	public void changeWaterY(){
		if(on && editObj.tag == "water"){
			fy.text = editObj.GetComponent<water>().waterForceY.ToString("0.####");
		}
	}
	
	
	
	// Update is called once per frame
	private void pxS(string a){
		if(a == editObj.transform.position.x.ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		
		undo.add(editObj,2,true);
		editObj.transform.position = new Vector3(x,editObj.transform.position.y,editObj.transform.position.z);
		undo.add(editObj,2,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
		
	}
	private void pyS(string a){
		if(a == editObj.transform.position.y.ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		
		undo.add(editObj,2,true);
		editObj.transform.position = new Vector3(editObj.transform.position.x,x,editObj.transform.position.z);
		undo.add(editObj,2,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
	}
	private void pzS(string a){
		if(a == (-editObj.transform.position.z).ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		
		undo.add(editObj,2,true);
		editObj.transform.position = new Vector3(editObj.transform.position.x,editObj.transform.position.y,Mathf.Clamp(-x,-10,10));
		undo.add(editObj,2,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
	}
	private void sxS(string a){
		if(a == (editObj.transform.localScale.x/50).ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a)*50;
		
		undo.add(editObj,10,true);
		editObj.transform.localScale= new Vector3(x,editObj.transform.localScale.y,0);
		undo.add(editObj,10,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
	}
	private void syS(string a){
		if(a == (editObj.transform.localScale.y/50).ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a)*50;
		
		undo.add(editObj,10,true);
		editObj.transform.localScale= new Vector3(editObj.transform.localScale.x,x,0);
		undo.add(editObj,10,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
	}
	private void rotS(string a){
		if(a == editObj.transform.rotation.eulerAngles.z.ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		
		undo.add(editObj,3,true);
		editObj.transform.rotation= Quaternion.Euler(0,0,x);
		undo.add(editObj,3,false);
		if(GameObject.Find("sizeStuff(Clone)")){
			GameObject.Find("sizeStuff(Clone)").GetComponent<sizeThing>().reselect(editObj.transform);
		}
	}
	private void fxS(string a){
		water water = editObj.GetComponent<water>();
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		if( x != water.waterForceX){
			undo.add(editObj, 7, true);
			water.waterForceX = x;
			if(!water.colorChanged){
				color(water);
			}
			undo.add(editObj, 7, false);

		}
	}
	private void fyS(string a){
		water water = editObj.GetComponent<water>();
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		if( x != water.waterForceY){
			undo.add(editObj, 8, true);
			water.waterForceY = x;
			
			if(!water.colorChanged){
				color(water);
			}
			undo.add(editObj, 8, false);

		}
	}
	private void bS(string a){
		if(a == (editObj.GetComponent<Draggable>().bounciness*100).ToString("0.###"))
			return;
		float x = 0;
		if(a != "")
			x = float.Parse(a);
		
		undo.add(editObj,11,true);
		editObj.GetComponent<Draggable>().bounciness = x/100;
		undo.add(editObj,11,false);
	}
	void color(water water){
		float X = water.waterForceX;
		float Y = water.waterForceY;
		var angle = (150 - (Mathf.Atan2(0 - Y, 0 - X)) * 180 / Mathf.PI)/360;
		print(angle + "angle");
		float h,s,v;
		Color.RGBToHSV(colori,out h, out s, out v);
		Color col = Color.HSVToRGB(angle,s,v);
		float alpha = Mathf.Clamp(Mathf.Sqrt(X*X+Y*Y)*0.27f,0.1f,0.7f);
		col.a = alpha;
		water.GetComponent<SpriteRenderer>().color = col;
		colorComponent.change(col,false);

	}
}

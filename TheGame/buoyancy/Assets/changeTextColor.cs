using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeTextColor : MonoBehaviour {

	public TextMeshProUGUI text;
	public Color color1;
	public Color color2;
	public float speed;
	void OnTriggerEnter2D(Collider2D other){
		Color now = text.color;
		StartCoroutine(colorChange(now,color2));
		
	}
	void OnTriggerExit2D(Collider2D other){
		Color now = text.color;
		StartCoroutine(colorChange(now,color1));
		
	}

	IEnumerator colorChange(Color col1, Color col2){
		float t = 0;
		while(t<1){
			t += Time.deltaTime / speed;
			text.color = Color.Lerp(col1,col2,t);
			yield return null;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsDisplay : MonoBehaviour {

	float deltaTime = 0.0f;
	float under40 = 1f;
 
	void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}
 
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
 
		GUIStyle style = new GUIStyle();
 
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		if(fps < 40){
			under40 = 1.0f / deltaTime;
		}
		string text = string.Format("{0:0.0} ms ({1:0.} fps) ({2:0.0} under 40)", msec, fps, under40);
		GUI.Label(rect, text, style);
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimation : MonoBehaviour {

	public float speed;
	public Vector2 AnchorMin;
	public Vector2 AnchorMax;
	Vector2 rAnchorMin;
	Vector2 rAnchorMax;
	RectTransform recT;
	bool start = true;
	float t = 0;
	bool an; 
	public float backMulti = 1;
	public void open(){
		an = true;
		recT = GetComponent<RectTransform>();
		if(start){
			rAnchorMax = recT.anchorMax;
			rAnchorMin = recT.anchorMin;
			start = false;
		}
		
		StartCoroutine(move());
	}
	public void close(){
		if(an){
			an = false;
			recT = GetComponent<RectTransform>();
			if(!an){
				StartCoroutine(moveBack());
			}
		}
			
		

	}
	IEnumerator move()
    {

		while(t <= 1 && an)
       {
            t += Time.deltaTime / speed/Time.timeScale;
            recT.anchorMin = Vector2.Lerp(rAnchorMin,AnchorMin, t);
			recT.anchorMax = Vector2.Lerp(rAnchorMax,AnchorMax, t);
            yield return null;
      }
    }
	IEnumerator moveBack()
    {

		while(t >= 0 & !an)
       {
            t -= (Time.deltaTime / speed) * backMulti/Time.timeScale;
            recT.anchorMin = Vector2.Lerp(rAnchorMin,AnchorMin, t);
			recT.anchorMax = Vector2.Lerp(rAnchorMax,AnchorMax, t);
            yield return null;
      }
	  if(!an){
		  gameObject.SetActive(false);
	  }
    }
	
}

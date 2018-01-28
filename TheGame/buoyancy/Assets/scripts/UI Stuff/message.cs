using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class message : MonoBehaviour {

	public Vector2 AnchorMin;
	public Vector2 AnchorMax;
	//float t = 0;
	Vector2 rAnchorMin;
	Vector2 rAnchorMax;
	public RectTransform recT;
	public float speed;
	public Color col1;
	public Color col2;
	public float wait;
	public TextMeshProUGUI texti;
	void Start(){
		rAnchorMax = recT.anchorMax;
		rAnchorMin = recT.anchorMin;
	}
	public void Message (string lol) {
		texti.text = lol;
		StopAllCoroutines();
		//t=2;
		StartCoroutine(move());
	}

	IEnumerator move()
    {
		bool lol = false;
		float t = 0;

		while(t <= 1)
       {
            t += Time.deltaTime / speed;
			print(t);
            recT.anchorMin = Vector2.Lerp(rAnchorMin,AnchorMin, t);
			recT.anchorMax = Vector2.Lerp(rAnchorMax,AnchorMax, t);
			GetComponent<Image>().color= Color.Lerp(col1,col2,t);
            yield return null;
      	}
		yield return new WaitForSeconds(wait); 
		while(t > 0)
      	{
			print("ok");
            t -= Time.deltaTime / speed;
            recT.anchorMin = Vector2.Lerp(rAnchorMin,AnchorMin, t);
			recT.anchorMax = Vector2.Lerp(rAnchorMax,AnchorMax, t);
			GetComponent<Image>().color= Color.Lerp(col1,col2,t);
            yield return null;
      	}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UianimRot : MonoBehaviour {

	// Use this for initialization
	public float time;
	public float amount;
	float t;
	public void rotate1(){
		t= 0;
		StartCoroutine(rotate(1));
	}
	public void rotate2(){
		t=0;
		StartCoroutine(rotate(-1));
	}
	IEnumerator rotate(float direction)
    {
		print("lololol");
		while(t < 1)
      	{
            t += Time.deltaTime / time;
			transform.Rotate(new Vector3(0,0,amount*100 * Time.deltaTime *direction * t));
			
            yield return null;
    	}
    }
}

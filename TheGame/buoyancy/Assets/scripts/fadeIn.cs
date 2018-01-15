using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIn : MonoBehaviour {

	public float fadeSpeed = 2;
	public Texture fadeTexture;
	float alpha;
	int drawDepth = -1000;
	private void OnGUI()
    {

        
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), fadeTexture);
		

        

    }
    void Start()
    {
         StartCoroutine(FadeImage(true));
    }
	IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                // set color with i as alpha
                alpha = i;
                yield return null;
            }
            this.enabled = false;
        }
    }
}

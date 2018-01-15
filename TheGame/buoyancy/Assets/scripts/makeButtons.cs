using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;
public class makeButtons : MonoBehaviour {

	int LevelCount;
	//public GameObject button;
	public GameObject skipButton;
	//GameObject thisButton;
	void Start () {
		if(PlayerPrefs.GetInt("unlockedLevel")<3 || !PlayerPrefs.HasKey("unlockedLevel")){
			PlayerPrefs.SetInt("unlockedLevel", 3);
		}
		LevelCount = Application.levelCount;
		int unlock = PlayerPrefs.GetInt("unlockedLevel");

		for(int i = unlock-2; i < transform.childCount; i++){
			transform.GetChild(i).GetComponent<Button>().interactable = false;
		}
		/*for(int i = 1; i<LevelCount-2; i++){
			thisButton=GameObject.Instantiate(button, transform.position, Quaternion.identity);
			thisButton.transform.parent = transform;
			thisButton.transform.localScale = new Vector3(1,1,1);
			thisButton.GetComponentInChildren<TextMeshProUGUI>().text = (i).ToString();
			thisButton.GetComponent<changeScene>().scene = i+2;
			if(i+2 > PlayerPrefs.GetInt("unlockedLevel")){
				thisButton.GetComponent<Button>().interactable = false;
			}
		}
		GetComponent<RectTransform>().sizeDelta = new Vector2((LevelCount-3)*100+(LevelCount-3),61);*/
		
		if(unlock < LevelCount){
			print(LevelCount);
			skipButton.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetChild(unlock-3).GetComponentInChildren<TextMeshProUGUI>().text;
			skipButton.GetComponent<changeScene>().scene =unlock;
		}
		else{
			skipButton.GetComponentInChildren<TextMeshProUGUI>().text = transform.GetChild(LevelCount-4).GetComponentInChildren<TextMeshProUGUI>().text;
			skipButton.GetComponent<changeScene>().scene = LevelCount-1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

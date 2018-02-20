using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TIME : MonoBehaviour {

	public TextMeshProUGUI time;
	public TextMeshProUGUI BestTime;
	//public TextMeshProUGUI time2;
	//public TextMeshProUGUI BestTime2;
	float t = 0;
	bool on = true;
	void Start () {
		if(Application.loadedLevel != 2 && PlayerPrefs.HasKey(Application.loadedLevel.ToString()) ){
			float ti = PlayerPrefs.GetFloat(Application.loadedLevel.ToString());
			BestTime.text = string.Format("{0:00}:{1:00}:{2:00}",(int)ti/60,(int)ti%60,(int)(ti*100)%100);
			//BestTime2.text = string.Format("{0:00}:{1:00}:{2:00}",(int)ti/60,(int)ti%60,(int)(ti*100)%100);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(on){
			t = Time.timeSinceLevelLoad;
			time.text = string.Format("{0:00}:{1:00}:{2:00}",(int)t/60,(int)t%60,(int)(t*100)%100);
		}
		
	}
	public void inGoal(){
		on = false;
		//time2.text = string.Format("{0:00}:{1:00}:{2:00}",(int)t/60,(int)t%60,(int)(t*100)%100);
		if(Application.loadedLevel != 2 && !PlayerPrefs.HasKey(Application.loadedLevel.ToString()) || t<PlayerPrefs.GetFloat(Application.loadedLevel.ToString())){
			PlayerPrefs.SetFloat(Application.loadedLevel.ToString(),t);
			BestTime.text = string.Format("{0:00}:{1:00}:{2:00}",(int)t/60,(int)t%60,(int)(t*100)%100);
		}
	}
}

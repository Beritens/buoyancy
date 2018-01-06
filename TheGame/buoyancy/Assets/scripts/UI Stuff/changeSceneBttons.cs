using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneBttons : MonoBehaviour {
	public void restart () {
		if(Application.loadedLevel >1){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	public void home(){
		if(Application.loadedLevel >1){
			Application.LoadLevel(0);
		}
		
	}
	public void skip(){
		if(Application.loadedLevel >2 && Application.loadedLevel < PlayerPrefs.GetInt("unlockedLevel")){
			if(Application.loadedLevel< Application.levelCount-1){
                Application.LoadLevel(Application.loadedLevel +1);
            
            }
        
            else{
                Application.LoadLevel(0);
            }
		}
        
		
	}

}

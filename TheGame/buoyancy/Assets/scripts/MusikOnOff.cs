using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusikOnOff : MonoBehaviour {

	// Use this for initialization
	public Sprite On;
	public Sprite Off;
	public Image button;
	public Sprite sOn;
	public Sprite sOff;
	public Image sbutton;
	AudioSource audi;
	void Start () {
		if(GameObject.Find("music")){
			audi = GameObject.Find("music").GetComponent<AudioSource>();
			if(!PlayerPrefs.HasKey("music")){
				PlayerPrefs.SetInt("music",1);
			}
			if(PlayerPrefs.GetInt("music") == 0){
				button.sprite = Off;
				audi.Stop();

			}
			else{
				if(!audi.isPlaying){
					audi.Play();
				}
				
			}
		}
		
		if(sbutton != null){
			if(!PlayerPrefs.HasKey("sound")){
				PlayerPrefs.SetInt("sound",1);
			}
			if(PlayerPrefs.GetInt("sound") == 0){
				sbutton.sprite = sOff;

			}
		}
		
	}
	
	// Update is called once per frame
	public void clickM () {
		if(PlayerPrefs.GetInt("music") == 1){
			PlayerPrefs.SetInt("music",0);
			button.sprite = Off;
			audi.Stop();
		}
		else{
			PlayerPrefs.SetInt("music",1);

			button.sprite = On;
			audi.Play();
		}
	}
	public void clickS(){
		if(PlayerPrefs.GetInt("sound") == 1){
			PlayerPrefs.SetInt("sound",0);
			sbutton.sprite = sOff;
		}
		else{
			PlayerPrefs.SetInt("sound",1);

			sbutton.sprite = sOn;
		}
	}
}

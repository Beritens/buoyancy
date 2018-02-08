using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loggedInAs : MonoBehaviour {

	public TextMeshProUGUI texti;
	public GameObject loginB;
	public GameObject logoutB;
	string url= "http://buoyancy.000webhostapp.com/update.php";
	// Use this for initialization
	void Start(){

		if(!PlayerPrefs.HasKey("Playername")){
			PlayerPrefs.SetString("Playername","");
			if(!PlayerPrefs.HasKey("updated")){
				PlayerPrefs.SetInt("updated",0);
			}
		}
		if(PlayerPrefs.GetString("Playername") == ""){
			logout();
		}
		else{
			login(PlayerPrefs.GetString("Playername"));
			if(PlayerPrefs.GetInt("updated") == 0){
				StartCoroutine(update());
			}
		}
	}
	public void login (string name) {
		texti.text = "You are logged in as "+ name;
		loginB.SetActive(false);
		logoutB.SetActive(true);
	}
	public void logout () {
		texti.text = "";
		loginB.SetActive(true);
		logoutB.SetActive(false);
	}
	IEnumerator update(){
		WWWForm form = new WWWForm();
		form.AddField("level",PlayerPrefs.GetInt("unlockedLevel"));
		form.AddField("name",PlayerPrefs.GetString("Playername"));
		WWW w = new WWW(url,form);
		yield return w;
		if(w.error != null){
			print(w.error);
		}
		else{
			print("updated");
			PlayerPrefs.SetInt("updated",1);
		}
	}
}

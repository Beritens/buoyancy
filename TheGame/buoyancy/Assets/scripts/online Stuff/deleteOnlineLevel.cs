using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deleteOnlineLevel : MonoBehaviour {

	public string name;
	public GameObject Button;
	string URL = "https://buoyancy.000webhostapp.com/delete.php";
	public void dele () {
		print("ok");
		StartCoroutine(del());
	}
	
	// Update is called once per frame
	IEnumerator del(){
		string[] splitty = name.Split(';');
		WWWForm form = new WWWForm();
		form.AddField("level", splitty[0]);
		form.AddField("name", splitty[1]);
		WWW w = new WWW(URL,form);
		yield return w;
		if(w.error != null){
			print(w.error);
		}
		else if(w.isDone){
			Destroy(Button);
			message message = GameObject.Find("Message").GetComponent<message>();
			message.speed = 0.2f;
			message.Message(w.text);
			GameObject.Find("rlyController").GetComponent<openSomething>().close();
		}
	}
	public void click(){
		string[] splitty = name.Split(';');
		
		GameObject.Find("rlyController").GetComponent<openSomething>().open();
		GameObject.Find("rlyText").GetComponent<TextMeshProUGUI>().text = "are you sure that you want to delete " + splitty[0] +"?";
		GameObject.Find("yesDelete").GetComponent<delPlaceholder>().button = this;
	}
}

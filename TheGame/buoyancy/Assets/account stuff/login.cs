using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class login : MonoBehaviour {

	public TMP_InputField email;
	public string url = "https://buoyancy.000webhostapp.com/Accounts/";
	public message message;

	public TMP_InputField password;
	public void click () {
		StartCoroutine(lol());
	}

	IEnumerator lol(){
		WWWForm form = new WWWForm();
		WWW w = new WWW(url+email.text+ "/infos.txt",form);

		print("www created");
 
        yield return w;
        print("after yield w");
        if (w.error != null)
        {
            print("error");
            print ( w.error );    
        }
		while(!w.isDone){
            print(w.progress);
        }
        if(w.isDone){
			
			List<string> sachen = new List<string>(w.text.Split('\n'));
			if(password.text == loadPlayerLevels.Decrypt(sachen[1]) ){
				PlayerPrefs.SetString("email",email.text);
				PlayerPrefs.SetInt("val",0);
				message.Message("you are logged in now");
				print("password is correct");
			}
			else{
				print("password is wrong");
			}
		}
	}
}

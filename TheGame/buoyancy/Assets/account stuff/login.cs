using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class login : MonoBehaviour {

	public TMP_InputField nickName;
	public string url = "https://buoyancy.000webhostapp.com/Accounts/";
	public message message;
	public loggedInAs text;
	public openSomething Openlogin;

	public TMP_InputField password;

	public makeButtons buttonStuff;
	public void click () {
		StartCoroutine(lol());
	}

	IEnumerator lol(){
		WWWForm form = new WWWForm();
		WWW w = new WWW(url+nickName.text+ "/infos.txt",form);

		print("www created");
 
        yield return w;
        print("after yield w");
		
        if (w.error != null)
        {
			message.Message("an error has occured");
            print("error");
            print ( w.error );    
        }
		else{
			while(!w.isDone){
            	print(w.progress);
			}
			if(w.isDone){
				List<string> sachen = new List<string>(w.text.Split('\n'));
				if(password.text == loadPlayerLevels.Decrypt(sachen[0]) ){
					print("hi");
					
					PlayerPrefs.SetString("Playername",nickName.text);
					PlayerPrefs.SetInt("unlockedLevel",int.Parse(sachen[1]));
					text.login(nickName.text);
					PlayerPrefs.SetInt("val",0);
					message.speed = 0.2f;
					message.Message("you are logged in now");
					Openlogin.close();
					buttonStuff.ButtonStuff();
				}
				else{
					message.speed = 0.02f;
					message.Message("the password is incorrect");
				}
			}
		}
		
	}
}

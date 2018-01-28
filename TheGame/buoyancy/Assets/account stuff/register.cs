using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class register : MonoBehaviour {

	public TMP_InputField Name;
	public TMP_InputField email;
	public TMP_InputField password;
	public TMP_InputField passwordcon;
	public message message;
	public openSomething registerThing;
	public openSomething infoTextThing;
	Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
	string url = "http://buoyancy.000webhostapp.com/register.php";
	public void click () {
		if(password.text == passwordcon.text){
			print("hi m8");
			if(Name.text != "" && regex.Match(email.text).Success && password.text != ""){
				print("so weit so gut");
				StartCoroutine(createAccount());
			}
			else{
				print("nope");
			}
		}
		else{
			message.Message("Password does not match the confirm password.");
		}
		
	}
	IEnumerator createAccount(){
		WWWForm form = new WWWForm();

		form.AddField("email", email.text);
		form.AddField("name", Name.text);
		form.AddField("password", loadPlayerLevels.Encrypt(password.text));

		WWW w = new WWW(url,form);
		yield return w;

		if (w.error != null)
        {
			message.Message("an error has occurred");
            print("error");
            print ( w.error );    
        }
		else if(w.isDone){
		    print(w.text);
			infoTextThing.open();
			registerThing.close();
			PlayerPrefs.SetInt("val",0);
			PlayerPrefs.SetString("email",email.text);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class register : MonoBehaviour {

	public TMP_InputField Name;
	public TMP_InputField password;
	public TMP_InputField passwordcon;
	public message message;
	public TextMeshProUGUI infoText;
	public openSomething registerThing;
	public openSomething infoTextThing;
	public loggedInAs loggedInAs;
	Regex regex = new Regex(@"\uD83D[\uDC00-\uDFFF]|\uD83C[\uDC00-\uDFFF]|\uFFFD|[^\u0020-\u007E]");
	public Regex forbiddenStuff = new Regex(@";|/|\\");
	string url = "http://buoyancy.000webhostapp.com/register.php";
	public void click () {
		if(password.text == passwordcon.text){
			if(Name.text != "" && password.text != ""){
				if(regex.Match(Name.text).Success || regex.Match(password.text).Success){
					print("emojis!");
					message.Message("please don't use emojis or other weird stuff");
				}
				else if(forbiddenStuff.Match(Name.text).Success|| forbiddenStuff.Match(password.text).Success){
					print("forbiddenStuff");
					message.Message("please don't use semicolons, slashes and other stuff like that");
				}
				else{
					print("so weit so gut");
					StartCoroutine(createAccount());
				}
				
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

		//form.AddField("email", email.text);
		form.AddField("name", Name.text);
		form.AddField("password", loadPlayerLevels.Encrypt(password.text)+"\n"+PlayerPrefs.GetInt("unlockedLevel").ToString());


		WWW w = new WWW(url,form);
		yield return w;

		if (w.error != null)
        {
			message.Message("sorry. an error has occurred");
            print("error");
            print ( w.error );    
        }
		else if(w.isDone){
			if(w.text == "an account with this name already exists"){
				message.Message("an account with this name already exists");
			}
			else{
				infoText.text= w.text;
				infoTextThing.open();
				registerThing.close();
				PlayerPrefs.SetString("Playername",Name.text);
				loggedInAs.login(Name.text);
				PlayerPrefs.SetInt("updated",1);
			}
		    
		}
	}
}

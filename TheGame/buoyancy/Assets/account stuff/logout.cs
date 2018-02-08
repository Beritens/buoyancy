using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logout : MonoBehaviour {

	public loggedInAs text;
	public void click () {
		PlayerPrefs.SetString("email", "");
		PlayerPrefs.SetString("Playername", "");
		PlayerPrefs.SetInt("val",0);
		text.logout();
	}
}

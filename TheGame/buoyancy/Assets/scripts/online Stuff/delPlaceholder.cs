using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delPlaceholder : MonoBehaviour {

	public deleteOnlineLevel button;
	public playCustom buttonLocal;
	public bool online;
	public void click () {
		if(online){
			button.dele();
		}
		else{
			buttonLocal.dele();
		}
		
	}
}

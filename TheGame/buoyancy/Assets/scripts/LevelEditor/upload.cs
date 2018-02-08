using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class upload : MonoBehaviour {
	public inGoal inGoal;
	public openSomething pauseMenu;
	public openSomething uploadStuff;
	public void click () {
		if(inGoal.inTheGoal){
			pauseMenu.close();
			uploadStuff.open();
			print("hi");
		}
		else{
			
			pauseMenu.close();
		}
	}
}

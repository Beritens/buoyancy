using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {

	public Animator anim;
	public GameObject trashCan;
	public GameObject copy;
	public GameObject waterStuff;
	public bool opeeen;
	public void openTheMenu () {
		trashCan.SetActive(true);
		copy.SetActive(true);
		anim.Play("openMenu");
		anim.SetBool("open",true);
		opeeen = true;
	}
	public void closeTheMenu () {

		
		anim.SetBool("open",false);
		trashCan.SetActive(false);
		copy.SetActive(false);
		waterStuff.SetActive(false);
		opeeen = false;
	}
	
	
}

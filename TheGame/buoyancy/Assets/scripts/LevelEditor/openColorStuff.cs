using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openColorStuff : MonoBehaviour {

	public GameObject color;
	public Animator anim;
	bool open;
	public void press () {
		open = !open;
		if(open){
			anim.SetBool("open", true);
			anim.Play("OpenColorStuff");

		}
		else{
			
			anim.SetBool("open", false);
		}
	}
	public void close(){
		open = false;
		anim.SetBool("open", false);
	}
}

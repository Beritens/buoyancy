using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class over : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public UnityEvent doSomething;
	public UnityEvent dontSomething;


	public void OnPointerEnter(PointerEventData eventData){
		if(doSomething != null){
			doSomething.Invoke();
		}
		
		
	}
	public void OnPointerExit(PointerEventData eventData){
		if(dontSomething != null){
			dontSomething.Invoke();
		}
		
	}
}

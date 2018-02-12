using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class changeSceneOnline : MonoBehaviour {

	public string name;
	public static bool tempo = false;
	public string url = "https://buoyancy.000webhostapp.com/Accounts/";

	public void press () {
		
		StartCoroutine(zeugs());
	}
	IEnumerator zeugs(){
		WWWForm form = new WWWForm();
		string[] Splity = name.Split(';');
		WWW w = new WWW(url+Splity[1]+"/"+Splity[0]+".txt",form);

		print("www created");
 
        yield return w;
        print("after yield w");
        if (w.error != null)
        {
            print("error");
            print ( w.error );
			if(w.error == "423 "){
				GameObject.Find("Message").GetComponent<message>().Message("sry, the server is currently sleeping. He will wake up in about 1 hour. This text is way too long to read in just a few seconds but I don't care");
			}
				   
			else if(w.error == "404 "){
				GameObject.Find("Message").GetComponent<message>().Message("this level does not exist");   
			}
			else{
				GameObject.Find("Message").GetComponent<message>().Message("something went horribly wrong");
			}
        }

        else if(w.isDone){
			if (!Directory.Exists (Application.persistentDataPath+"/temporary")) {
			
				Directory.CreateDirectory (Application.persistentDataPath+"/temporary");
			}
			List<string> names = new List<string>(w.text.Split('\n'));
			//names.RemoveAt(0);

			File.WriteAllLines(Application.persistentDataPath+"/temporary/temporaryOnline.txt", names.ToArray());
			tempo = true;
			Application.LoadLevel(2);
		}
	}
}

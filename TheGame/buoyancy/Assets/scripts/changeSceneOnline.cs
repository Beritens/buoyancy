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
        }
		while(!w.isDone){
            print(w.progress);
        }
        if(w.isDone){
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

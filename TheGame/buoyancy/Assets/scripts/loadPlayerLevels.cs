using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using TMPro;
using System.Security.Cryptography;

public class loadPlayerLevels : MonoBehaviour {

	string url = "https://buoyancy.000webhostapp.com/list.txt";
    public GameObject container;
    public GameObject Button;
    public GameObject LoadMoreButton;
    List<string> Names = new List<string>();
    int whereAmI = 0;

    public void Start(){
        if(File.Exists(Application.persistentDataPath+"/PlayerLevelsList.txt")){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/PlayerLevelsList.txt");
            
            while(!sr.EndOfStream){
                Names.Add(Decrypt(sr.ReadLine()));
            }
            sr.Close();
            ListFiles(0,100);
        }
        
        
    }
	public void click(){
		StartCoroutine(stuff());
	}
	IEnumerator stuff(){
		WWWForm form = new WWWForm();
		WWW w = new WWW(url,form);
        WWW names = new WWW("https://buoyancy.000webhostapp.com/AccountList.txt",form);
        print("www created");
        yield return names;
        yield return w;
        print("after yield w");
        if (names.error != null)
        {
            print("error");
            print ( w.error );    
        }
        if (w.error != null)
        {
            print("error");
            print ( w.error );    
        }
        
        if(names.isDone){
            string [] split = names.text.Split(new Char[] { ';','\n' });
            if(w.isDone){
                string[] bruh = w.text.Split('\n');
                string[] lol = new string[bruh.Length];
                for(int i = 0; i<lol.Length; i++){
                    //bruh[i] +=";"+split[Array.IndexOf(split, bruh[i].Split(';')[1])];
                    if(bruh[i] != ""){
                        print(bruh[i]);
                        string emailtxt = bruh[i].Split(';')[1];
                        bruh[i]+=";"+ split[Array.IndexOf(split, emailtxt)+1];
                    }
                    
                    lol[i] = Encrypt(bruh[i]);
                }
                Names.Clear();
                Names.AddRange(bruh);
                File.WriteAllLines(Application.persistentDataPath+"/PlayerLevelsList.txt",lol);

                foreach (Transform child in container.transform) {
                    GameObject.Destroy(child.gameObject);
                }
                ListFiles(0,100);
            }
        }
        
	}
    public void loadMore(){
        GameObject.Destroy(container.transform.GetChild(container.transform.childCount-1).gameObject);
        ListFiles(whereAmI,100);
        
    }
    public void ListFiles(int start, int howMany){
        

        if(Names.Count >= start+howMany){
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, (start+howMany+1)*32);
            for(int i = start+howMany-1; i> start-1; i--){
                if(Names[i] != ""){
                    GameObject bob = GameObject.Instantiate(Button,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = Names[i];
                    string[] nameStuff = Names[i].Split(';');
                    bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                    bob.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nameStuff[nameStuff.Length-1];
                }
                
            }
            GameObject boby = GameObject.Instantiate(LoadMoreButton,new Vector3(0,0,0), Quaternion.identity);
                    
            boby.transform.parent = container.transform;
            boby.transform.localScale = new Vector3(1,1,1);
            whereAmI = start+howMany;
        }
        else{
            print(Names.Count);
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, (Names.Count-1)*32);
            for(int i = Names.Count-1; i> start -1; i--){
                if(Names[i] != ""){
                    GameObject bob = GameObject.Instantiate(Button,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = Names[i];
                    string[] nameStuff = Names[i].Split(';');
                    bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                    bob.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nameStuff[nameStuff.Length-1];
                }
                
            }
        }
    }
    private static string hash = "miau";

    //Encrypt
    public static string Encrypt(string input){
        byte[] data = UTF8Encoding.UTF8.GetBytes(input);
        using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
            byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using(TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider(){Key = key, Mode = CipherMode.ECB, Padding= PaddingMode.PKCS7}){
                ICryptoTransform tr = trip.CreateEncryptor();
                byte[] result = tr.TransformFinalBlock(data,0,data.Length);
                return Convert.ToBase64String(result,0,result.Length);
            }
        }
    }
    //Decrypt
    public static string Decrypt(string input){
        byte[] data = Convert.FromBase64String(input);
        using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
            byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using(TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider(){Key = key, Mode = CipherMode.ECB, Padding= PaddingMode.PKCS7}){
                ICryptoTransform tr = trip.CreateDecryptor();
                byte[] result = tr.TransformFinalBlock(data,0,data.Length);
                return UTF8Encoding.UTF8.GetString(result);
            }
        }
    }
}

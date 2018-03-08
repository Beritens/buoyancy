using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using TMPro;
using System.Security.Cryptography;

public class loadPlayerLevels : MonoBehaviour {

	string url = "https://buoyancy.000webhostapp.com/list.txt";
    public GameObject container;
    public GameObject Button;
    public GameObject MyButton;
    public GameObject LoadMoreButton;
    public TMP_InputField searchBar;
    bool searching = false;
    List<string> Names = new List<string>();
    List<string> searched = new List<string>();
    List<string> mine = new List<string>();
    int whereAmI = 0;
    bool loadMine = true;
    bool searchmine = false;
    public GameObject before;
    public GameObject after;
    public GameObject somethingwentWrong;
    //public message message;

    public void Start(){
      /*  if(File.Exists(Application.persistentDataPath+"/PlayerLevelsList.txt")){
            StreamReader sr = new StreamReader(Application.persistentDataPath+"/PlayerLevelsList.txt");
            
            while(!sr.EndOfStream){
                Names.Add(sr.ReadLine());
            }
            

            sr.Close();
            Names.RemoveAt(Names.Count-1);
            //Names.Sort();  << das würde es alphabetisch ordnen
            //Names.Reverse(); 
            ListFiles(Names.Count,Names.Count-100,Names);
        }*/
        //StartCoroutine(stuff());

        searchBar.onEndEdit.AddListener(search);
        
    }
    public void playOnline(){
        before.SetActive(false);
        after.SetActive(true);
        StartCoroutine(stuff());
    }
	public void click(){
        foreach (Transform child in container.transform) {
            GameObject.Destroy(child.gameObject);
        }
		StartCoroutine(stuff());
	}
	IEnumerator stuff(){
		WWWForm form = new WWWForm();
		WWW w = new WWW(url,form);
        yield return w;
        print("after yield w");
        
        if (w.error != null)
        {
            //message.Message("something went wrong");
            Names.Clear();
            print("error");
            print ( w.error ); 
            /*if(before.activeSelf){
                before.SetActive(false);
            }*/
            somethingwentWrong.SetActive(true);
        }
        else if(w.isDone){
            somethingwentWrong.SetActive(false);
            //print("hi");
            string[] bruh = w.text.Split('\n');
            if(!bruh[0].Contains(";")){
                //message.Message("sry, the server is currently sleeping. He will wake up in about 1 hour. This text is way too long to read in just a few seconds but I don't care");
                yield break;
            }
            //string[] lol = new string[bruh.Length];
            /*for(int i = 0; i<lol.Length; i++){
                //bruh[i] +=";"+split[Array.IndexOf(split, bruh[i].Split(';')[1])];
                lol[i] = Encrypt(bruh[i]);
            }*/
            Names.Clear();
            Names.AddRange(bruh);
            Names.RemoveAt(Names.Count-1);
            //File.WriteAllLines(Application.persistentDataPath+"/PlayerLevelsList.txt",bruh);
            loadMine = true;

            foreach (Transform child in container.transform) {
                GameObject.Destroy(child.gameObject);
            }
            if(searching){
                search(searchBar.text);
               // message.Message("refreshed!");
            }
            else if(searchmine){
                loadMyLevels();
               // message.Message("refreshed!");
            }
            else{
                ListFiles(Names.Count,Names.Count-100,Names);
               // message.Message("refreshed!");
            }
            
            
        }
        
	}
    public void loadMore(){
        GameObject.Destroy(container.transform.GetChild(container.transform.childCount-1).gameObject);
        if(searching){
            ListFiles(whereAmI,whereAmI-100,searched);
        }
        else if(searchmine){
            ListMine(whereAmI,whereAmI-100,mine);
        }
        else{
            ListFiles(whereAmI,whereAmI-100,Names);
        }
        
        
    }
    public void listAll(){
        foreach (Transform child in container.transform) {
            GameObject.Destroy(child.gameObject);
        }
        searchmine = false;
        searching = false;
        ListFiles(Names.Count,Names.Count-100,Names);
    }
    void ListFiles(int start, int bisWO, List<string> list){
        
        if(bisWO > 0){
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, ((list.Count-bisWO)+1)*32);
            for(int i = start-1; i> bisWO-1; i--){
                if(list[i] != ""){
                    GameObject bob = GameObject.Instantiate(Button,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = list[i];
                    string[] nameStuff = list[i].Split(';');
                    bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                    bob.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nameStuff[nameStuff.Length-1];
                }
                
            }
            GameObject boby = GameObject.Instantiate(LoadMoreButton,new Vector3(0,0,0), Quaternion.identity);
                    
            boby.transform.parent = container.transform;
            boby.transform.localScale = new Vector3(1,1,1);
            whereAmI = bisWO;
        }
        else{
            
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, (list.Count)*32);
            for(int i = list.Count-1; i> -1; i--){
                if(list[i] != ""){
                    GameObject bob = GameObject.Instantiate(Button,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = list[i];
                    string[] nameStuff = list[i].Split(';');
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
        print("hihi");
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
    public void loadMyLevels(){
        foreach (Transform child in container.transform) {
            GameObject.Destroy(child.gameObject);
        }
        if(loadMine == true){
            mine.Clear();
            for(int i = 0;i<Names.Count;i++){
                if(Names[i] != ""){
                    string[] splitt = Names[i].Split(';');
                    if(splitt[1] == PlayerPrefs.GetString("Playername")){
                    /* GameObject bob = GameObject.Instantiate(MyButton,new Vector3(0,0,0), Quaternion.identity);
                        lol++;
                        bob.transform.parent = container.transform;
                        bob.transform.localScale = new Vector3(1,1,1);
                        bob.GetComponent<changeSceneOnline>().name = Names[i];
                        string[] nameStuff = Names[i].Split(';');
                        bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                        bob.transform.GetChild(1).GetComponent<deleteOnlineLevel>().name = Names[i];*/
                        mine.Add(Names[i]);
                    }
                }
                
            }
            
            loadMine = false;
            
            
        }
        searchmine = true;
        if(searching){
            search(searchBar.text);
        }
        else{
            ListMine(mine.Count,mine.Count-100,mine);
        }
        
        container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, mine.Count*32);
    }
    public void sB(){
        search(searchBar.text);
    }
    public void search(string InputText){
        foreach (Transform child in container.transform) {
            GameObject.Destroy(child.gameObject);
        }
        List<string> list;
        if(searchmine){
            list = mine;
            print("hello");
        }
        else{
            list = Names;
        }
        
        
        if(InputText != ""){
            
            searched = new List<string>();
            for(int i = 0; i<list.Count; i++){
                if(list[i].ToLower().Contains(InputText.ToLower())){
                    searched.Add(list[i]);
                }
            }
            searching = true;
            /*if(searchmine){
                ListMine(mine.Count,mine.Count-100,searched);
            }
            else{*/
            ListFiles(searched.Count,searched.Count-100,searched);
            //}
            
            

        }
        else{
            searching = false;
            if(searchmine){
                ListMine(mine.Count,mine.Count-100,mine);
            }
            else{
                ListFiles(Names.Count,Names.Count-100,Names);
            }
            
        }

    }
    void ListMine(int start, int bisWO, List<string> list){
        
        if(bisWO > 0){
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, ((list.Count-bisWO)+1)*32);
            for(int i = start-1; i> bisWO-1; i--){
                if(list[i] != ""){
                    
                    GameObject bob = GameObject.Instantiate(MyButton,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = list[i];
                    string[] nameStuff = list[i].Split(';');
                    bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                    bob.transform.GetChild(1).GetComponent<deleteOnlineLevel>().name = list[i];
                }
                
            }
            GameObject boby = GameObject.Instantiate(LoadMoreButton,new Vector3(0,0,0), Quaternion.identity);
                    
            boby.transform.parent = container.transform;
            boby.transform.localScale = new Vector3(1,1,1);
            whereAmI = bisWO;
        }
        else{
            
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(container.GetComponent<RectTransform>().sizeDelta.x, (list.Count)*32);
            for(int i = list.Count-1; i> -1; i--){
                if(list[i] != ""){
                    GameObject bob = GameObject.Instantiate(MyButton,new Vector3(0,0,0), Quaternion.identity);
                    
                    bob.transform.parent = container.transform;
                    bob.transform.localScale = new Vector3(1,1,1);
                    bob.GetComponent<changeSceneOnline>().name = list[i];
                    string[] nameStuff = list[i].Split(';');
                    bob.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = nameStuff[0];
                    bob.transform.GetChild(1).GetComponent<deleteOnlineLevel>().name = list[i];
                }
                
            }
        }
    }
   
        

}

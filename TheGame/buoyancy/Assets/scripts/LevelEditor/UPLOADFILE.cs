using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using TMPro;
using System.Text.RegularExpressions;
public class UPLOADFILE : MonoBehaviour {

	// Use this for initialization
	public loadLevel Ll;
	public TMP_InputField text;
    public TMP_InputField text2;
    string Listpath;
    public openSomething uploadWindow;
    List<string> names = new List<string>();
	// Update is called once per frame
    
	public void click () {
        if(text.text != "" && text2.text != ""){
            Listpath = Application.persistentDataPath+"/LocalList.txt";
            //text.text = Regex.Replace(text.text, @"\uD83D[\uDC00-\uDFFF]|\uD83C[\uDC00-\uDFFF]|\uFFFD", ":)");
            //text2.text = Regex.Replace(text2.text, @"\uD83D[\uDC00-\uDFFF]|\uD83C[\uDC00-\uDFFF]|\uFFFD", ":)");
            text.text = Regex.Replace(text.text, @"[^\u0020-\u007E]", ":)");
            text2.text = Regex.Replace(text2.text, @"[^\u0020-\u007E]", ":)");
            StartCoroutine(UploadLevel());
            
            PlayerPrefs.SetString("name",text2.text);
        }
        
	}
	 IEnumerator UploadLevel()  
    {
        StreamReader sr;
       if(save.tempoPlay){
           sr = new StreamReader(Application.persistentDataPath+"/temporary/temporary.txt");
       }
       else{
           sr = new StreamReader(playCustom.path2);
       }
       
        //converting the xml to bytes to be ready for upload
        byte[] levelData =Encoding.UTF8.GetBytes(sr.ReadToEnd());
       sr.Close();

       
        //generate a long random file name , to avoid duplicates and overwriting
        string fileName = text.text +";"+ text2.text+ ";"+ Ll.random + ".txt";
        //fileName = Regex.Replace(fileName, @"\uD83D[\uDC00-\uDFFF]|\uD83C[\uDC00-\uDFFF]|\uFFFD", ":)");
        
        print(fileName);
       
        //if you save the generated name, you can make people be able to retrieve the uploaded file, without the needs of listings
        //just provide the level code name , and it will retrieve it just like a qrcode or something like that, please read below the method used to validate the upload,
        //that same method is used to retrieve the just uploaded file, and validate it
        //this method is similar to the one used by the popular game bike baron
        //this method saves you from the hassle of making complex server side back ends which enlists available levels
        //this way you could enlist outstanding levels just by posting the levels code on a blog or forum, this way its easier to share, without the need of user accounts or install procedures
        WWWForm form = new WWWForm();
 
        print("form created ");
       
        form.AddField("action", "level upload");
 
        form.AddField("file","file");
 
        form.AddBinaryData ( "file", levelData, fileName,"text/txt");
 
        print("binary data added ");
        //change the url to the url of the php file
        WWW w = new WWW("http://buoyancy.000webhostapp.com/LevelUpload.php",form);
        print("www created");
 
        yield return w;
        print("after yield w");
        if (w.error != null)
        {
            print("error");
            print ( w.error );    
        }
        else
        {
            //this part validates the upload, by waiting 5 seconds then trying to retrieve it from the web
            if(w.uploadProgress == 1 && w.isDone)
            {
                //yield return new WaitForSeconds(5);
                //change the url to the url of the folder you want it the levels to be stored, the one you specified in the php file
                WWW w2 = new WWW("http://buoyancy.000webhostapp.com/Levels/" + fileName);
                
                yield return w2;
                if(w2.error != null)
                {
                    print("error 2");
                    print ( w2.error );  
                }
                else
                {
                    //then if the retrieval was successful, validate its content to ensure the level file integrity is intact
                    if(w2.text != null && w2.text != "") 
                    {
                        if(w2.text.Contains("random")&&w2.text.Contains("end"))
                        {
                            bool inList = false;
                            bool ok = false;
                            if(File.Exists(Listpath)){
                                ok = true;
                                StreamReader sReader = new StreamReader(Listpath);
                                while(!sReader.EndOfStream){
                                    names.Add(sReader.ReadLine());
                                }
                                sReader.Close();
                            }
                            for(int i=0; i<names.Count; i++){
                                if(names[i]==fileName){
                                    inList = true;
                                }
                            }
                            if(!inList){
                                StreamWriter sWriter;
                                if (!ok) {
                                    sWriter = File.CreateText(Listpath);
                                    
                                    
                                }
                                else{
                                    sWriter = new StreamWriter(Listpath, true);
                                }
                                sWriter.WriteLine(fileName);
                                sWriter.Close();
                            }
                            
                            
                            //and finally announce that everything went well
                            
                            print ( "Finished Uploading Level " + fileName);
                            uploadWindow.close();
                        }
                        else
                        {
                            print ( "Level File " + fileName + " is Invalid");
                        }
                    }
                    else
                    {
                        print ( "Level File " + fileName + " is Empty");
                    }
                }
            }      
        }
    }
}

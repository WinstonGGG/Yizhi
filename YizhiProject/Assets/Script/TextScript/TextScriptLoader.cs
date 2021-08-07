using System;
using System.IO;
using System.Text;
using UnityEngine;

public class TextScriptLoader : MonoBehaviour
{
    public TextAsset[] textScripts;
    public string[,] textScript = new string[20,100];
    //public string UTF8String(textScript[,]);
    void Start()
    {
        int fileOrderCounter = 0;
        foreach (TextAsset rawText in textScripts)
        {
        
            
            // Unity load script file template 
            // TextAsset rawText = Resources.Load("TextScript/"+s) as TextAsset;
            string[] a = rawText.text.Split('\n');
            for (int i = 0; i < a.Length; i++)
            {
               // string f = UTF8String(a);
               textScript[fileOrderCounter, i] = UTF8String(a[i]);
            }
            Debug.Log(textScript[0,2]);
            fileOrderCounter++;
        }
    }

    public string[,] getTextScript()
    {
        return textScript;
    }

    public string UTF8String(string input){
        UTF8Encoding utf8 = new UTF8Encoding(); 
        return utf8.GetString(utf8.GetBytes(input));
    }
}

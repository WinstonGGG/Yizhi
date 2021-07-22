using System;
using System.IO;
using UnityEngine;

public class TextScriptLoader : MonoBehaviour
{
    public string[]textScriptName;
    public string[,]textScript = new string[20,100];
    void Start()
    {
        int fileOrderCounter = 0;
        foreach (string s in textScriptName)
        {
            TextAsset rawText = Resources.Load("TextScript/"+s) as TextAsset;
            string[] a = rawText.text.Split('\n');
            for (int i = 0; i < a.Length; i++)
            {
               textScript[fileOrderCounter, i] = a[i];
            }
            Debug.Log(textScript[0,2]);
            fileOrderCounter++;
        }
    }

    public string[,] getTextScript()
    {
        return textScript;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVGdata : MonoBehaviour
{
    public List<DialogContent> contents;
}

[System.Serializable]
public class DialogContent
{
    public string dialogText;
    public bool charaADisplay;
    public bool charaBDisplay;
}

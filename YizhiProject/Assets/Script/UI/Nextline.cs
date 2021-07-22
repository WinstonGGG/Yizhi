using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextline : MonoBehaviour
{
    public GameObject sm;
    public void playeNext()
    {
        sm.GetComponent<ScriptManager>().playNextLine();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextline : MonoBehaviour
{
    public GameObject sm;
    public GameObject em;
    public void playeNext()
    {
        if (!sm.GetComponent<ScriptManager>().needJump)
            sm.GetComponent<ScriptManager>().playNextLine();
        else
            sm.GetComponent<ScriptManager>().playCertainScript(-1, -1);
    }
    public void playOption(int option) {
        EffectManager emComponent = em.GetComponent<EffectManager>();
        sm.GetComponent<ScriptManager>().playCertainScript(-1, emComponent.jumpLine[option]);
        emComponent.options.SetActive(false);
        emComponent.button.SetActive(true);
    }
}

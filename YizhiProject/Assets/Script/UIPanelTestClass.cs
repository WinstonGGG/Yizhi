using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelTestClass : MonoBehaviour
{
    public UIPanel uiPanel;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            uiPanel.ShowCharaA(false);
        }
        if (Input.GetKeyDown("2"))
        {
            uiPanel.ShowCharaB(false);
        }
        if (Input.GetKeyDown("3"))
        {
            uiPanel.ShowContentBg(false);
        }
        if (Input.GetKeyDown("4"))
        {
            uiPanel.ShowContentText(false);
        }
        /* if (Input.GetKeyDown("5"))
        {
            uiPanel.ShowContentText("abcde");
        }
        */
    }
}

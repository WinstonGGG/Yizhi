using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // public List<string> contents;
    public AVGdata data;
    public UIPanel panel;
    [SerializeField]
    private int curLine;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Open dialog
        if (Input.GetKeyDown("1"))
        {
            Init();
            // LoadText(data.contents[curLine].dialogText);
            LoadContent(data.contents[curLine].dialogText, data.contents[curLine].charaADisplay, data.contents[curLine].charaBDisplay);
            ShowUI();
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
            if (curLine >= data.contents.Count)
            {
                curLine = data.contents.Count;
                Init(); // Close UI Panel when dialogue finished
            }
            // LoadText(data.contents[curLine].dialogText);
            LoadContent(data.contents[curLine].dialogText, data.contents[curLine].charaADisplay, data.contents[curLine].charaBDisplay);
        }
    }

    private void Init()
    {
        HideUI();
        curLine = 0;
        panel.SetContentText("");
    }

    void HideUI()
    {
        //panel.ShowCharaA(false);
        //panel.ShowCharaB(false);
        //panel.ShowContentBg(false);
        //panel.ShowContentText(false);
        panel.ShowCanvas(false);
    }

    void ShowUI()
    {
        //panel.ShowCharaA(true);
        //panel.ShowCharaB(true);
        //panel.ShowContentBg(true);
        //panel.ShowContentText(true);
        panel.ShowCanvas(true);
    }

    void NextLine()
    {
        curLine++;
    }

    void LoadText(string value)
    {
        panel.SetContentText(value);
    }

    void LoadContent(string value, bool charaADisplay, bool charaBDisplay)
    {
        panel.SetContentText(value);
        panel.ShowCharaA(charaADisplay);
        panel.ShowCharaB(charaBDisplay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<string> contents;
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
            LoadText(contents[curLine]);
            ShowUI();
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
            if (curLine >= contents.Count)
            {
                curLine = contents.Count;
                Init(); // Close UI Panel when dialogue finished
            }
            LoadText(contents[curLine]);
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
        panel.ShowCharaA(false);
        panel.ShowContentBg(false);
        panel.ShowContentText(false);
    }

    void ShowUI()
    {
        panel.ShowCharaA(true);
        panel.ShowContentBg(true);
        panel.ShowContentText(true);
    }

    void NextLine()
    {
        curLine++;
    }

    void LoadText(string value)
    {
        panel.SetContentText(value);
    }
}

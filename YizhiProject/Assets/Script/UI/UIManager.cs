using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // public List<string> contents;
    public AVGdata data;
    public AVGAssetConfig asset;
    public UIPanel panel;
    [SerializeField]
    private int curLine;
    enum sentenceType {SENT, QUES, ANS}; // will be used to keep track of different sentence types
    sentenceType curSen;
    public Button m_A, m_B, m_C;

    // Start is called before the first frame update
    void Start()
    {
        // curSen = sentenceType.None;
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
            LoadCharaTexture(asset.charaATex, asset.charaBTex);
            ShowUI();
            m_A.gameObject.SetActive(false);
            m_B.gameObject.SetActive(false);
            m_C.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (curSen == sentenceType.SENT)
            {
                NextLine();
            }
            else if (curSen == sentenceType.ANS)
            {
                //answerDictionary;
            }
            else if (curSen == sentenceType.QUES)
            {
                m_A.gameObject.SetActive(true);
                m_B.gameObject.SetActive(true);
                m_C.gameObject.SetActive(true);
                Debug.Log("you have to choose an option from A, B or C");
            }

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
        LoadContent(data.contents[curLine].dialogText, data.contents[curLine].charaADisplay, data.contents[curLine].charaBDisplay);
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

    void LoadCharaTexture(Texture charaATex, Texture charaBTex)
    {
        panel.ChangeCharaATex(charaATex);
        panel.ChangeCharaATex(charaBTex);
    }
}

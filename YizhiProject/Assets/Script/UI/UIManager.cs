using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GOManager go;
    
    // public List<string> contents;
    public AVGdata data;
    public UIPanel panel;
    [SerializeField]
    private int curLine;
    public enum SentenceType {SENT, QUES, ANS}; // will be used to keep track of different sentence types
    private SentenceType curSen;
    public SentenceType[] senTypes;
    private ChangeQuestion questionTrigger;


    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("GameObjectManager").GetComponent<GOManager>();

        questionTrigger = go.questionTrigger;
        curSen = SentenceType.SENT;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Open dialog
        if (Input.GetKeyDown("1"))
        {
            Init();
            ShowUI();
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Dealing with the sentence showing now
            curSen = senTypes[curLine];
            if (curSen == SentenceType.SENT)
            {
                curLine++;
            }
            else if (curSen == SentenceType.ANS)
            {
                questionTrigger.ShowFromAnswer(curLine);
            }
            else if (curSen == SentenceType.QUES)
            {
                Debug.Log("Choose from A, B or C");
            }

            //Dealing with sentence that will show after this click
            if (curLine >= data.contents.Count)
            {
                curLine = data.contents.Count;
                Init(); // Close UI Panel when dialogue finished
            }
            curSen = senTypes[curLine];
            if (curSen == SentenceType.QUES)
            {
                go.buttonA.SetActive(true);
                go.buttonB.SetActive(true);
                go.buttonC.SetActive(true);
            }
            
            LoadContent(data.contents[curLine].dialogText, data.contents[curLine].charaADisplay, data.contents[curLine].charaBDisplay);
        }
    }

    private void Init()
    {
        curLine = 0;
        // LoadText(data.contents[0].dialogText);
        LoadContent(data.contents[curLine].dialogText, data.contents[curLine].charaADisplay, data.contents[curLine].charaBDisplay);
        go.buttonA.SetActive(false);
        go.buttonB.SetActive(false);
        go.buttonC.SetActive(false);
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

    public void LoadText(string value)
    {
        panel.SetContentText(value);
    }

    public void LoadContent(string value, bool charaADisplay, bool charaBDisplay)
    {
        panel.SetContentText(value);
        panel.ShowCharaA(charaADisplay);
        panel.ShowCharaB(charaBDisplay);
    }

    public void UpdateCurLine(int newLine) {
        curLine = newLine;
    }

    public int GetCurLine() {
        return curLine;
    }
}

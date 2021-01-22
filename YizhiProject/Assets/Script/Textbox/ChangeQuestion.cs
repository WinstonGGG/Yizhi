using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeQuestion : MonoBehaviour
{
    public GOManager go;
    // first int shows current question number; second int shows the option: A=1, B=2, C=3
    private Dictionary<Tuple<int, int>, int> questionDictionary = new Dictionary<Tuple<int, int>, int>();
    private Dictionary<int, int> answerDictionary = new Dictionary<int, int>();
    public AVGdata data;

    void Start()
    {
        go = GameObject.Find("GameObjectManager").GetComponent<GOManager>();

        questionDictionary.Add(new Tuple<int, int>(4, 1), 5);
        questionDictionary.Add(new Tuple<int, int>(4, 2), 6);
        answerDictionary.Add(5,7);
        answerDictionary.Add(6,7);
    }

    // Start is called before the first frame update
    public void ShowNextQuestion(int option) {
        int nextQuestionNum = 0;
        try {
            nextQuestionNum = questionDictionary[new Tuple<int, int>(go.manager.GetCurLine(), option)];
            go.manager.LoadText(data.contents[nextQuestionNum].dialogText);
            go.manager.UpdateCurLine(nextQuestionNum);
        }
        catch(Exception e) {
            Debug.Log("Key Not Found");
        }

        go.buttonA.SetActive(false);
        go.buttonB.SetActive(false);
        go.buttonC.SetActive(false);
    }

    public void ShowFromAnswer(int curLine) {
        go.manager.UpdateCurLine(answerDictionary[curLine]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeQuestion : MonoBehaviour
{
    public int currentQuestionNum = 0;
    public GOManager go;
    public string question0;
    public string question1;
    public string question2;
    public string question3;
    public string question4;
    // first int shows current question number; second int shows the option: A=1, B=2, C=3
    private Dictionary<Tuple<int, int>, int> questionDictionary = new Dictionary<Tuple<int, int>, int>();
    private string[] questions = new string[10];

    void Start()
    {
        go = GameObject.Find("GameObjectManager").GetComponent<GOManager>();go.textComponent.text = question0;
        questions[0] = question0;
        questions[1] = question1;
        questions[2] = question2;
        questions[3] = question3;
        questions[4] = question4;
        questionDictionary.Add(new Tuple<int, int>(0, 1), 1);
        questionDictionary.Add(new Tuple<int, int>(0, 2), 2);
        questionDictionary.Add(new Tuple<int, int>(0, 3), 3);
        questionDictionary.Add(new Tuple<int, int>(2, 2), 4);
        questionDictionary.Add(new Tuple<int, int>(1, 2), 0);
    }

    // Start is called before the first frame update
    public void ShowNextQuestion(int option) {
        int nextQuestionNum = 0;
        try {
            nextQuestionNum = questionDictionary[new Tuple<int, int>(currentQuestionNum, option)];
            go.textComponent.text = questions[nextQuestionNum];
            currentQuestionNum = nextQuestionNum;
        }
        catch(Exception e) {
            Debug.Log("Key Not Found");
        }
    }
}

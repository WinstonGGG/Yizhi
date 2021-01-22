using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // called when button is pressed
    public GOManager go;
    public ChangeQuestion questionTrigger;

    void Start(){
        go = GameObject.Find("GameObjectManager").GetComponent<GOManager>();
        questionTrigger = go.questionTrigger;
    }

    public void TaskOnClickA()
    {
        questionTrigger.ShowNextQuestion(1);
        Debug.Log("You have clicked button A!");
    }
 
    public void TaskOnClickB()
    {
        questionTrigger.ShowNextQuestion(2);
        Debug.Log("You have clicked button B!");
    }

    public void TaskOnClickC()
    {
        questionTrigger.ShowNextQuestion(3);
        Debug.Log("You have clicked button C!");
    }
}
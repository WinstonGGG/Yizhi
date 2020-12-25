using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // called when button is pressed
    public Button m_A, m_B, m_C;
    public GOManager go;
    public ChangeQuestion questionTrigger;

    /*void Start()
    {
        m_A.onClick.AddListener(delegate { TaskWithParameters("A"); });
        m_B.onClick.AddListener(delegate { TaskWithParameters("B"); });
        m_C.onClick.AddListener(delegate { TaskWithParameters("C"); });
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    } */
    
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
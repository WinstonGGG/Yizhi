using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // called when button is pressed
    public Button m_A, m_B, m_C;

    void Start()
    {
        m_A.onClick.AddListener(delegate { TaskWithParameters("A"); });
        m_B.onClick.AddListener(delegate { TaskWithParameters("B"); });
        m_C.onClick.AddListener(delegate { TaskWithParameters("C"); });
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }
}
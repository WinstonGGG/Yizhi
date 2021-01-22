using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOManager : MonoBehaviour
{
    public GameObject textBackground;
    public ChangeQuestion questionTrigger;
    public GameObject textGO;
    public Text textComponent;
    public GameObject buttonA, buttonB, buttonC;

    public UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        textBackground = GameObject.Find("TextBackground");
        questionTrigger = textBackground.GetComponent<ChangeQuestion>();
        textGO = GameObject.Find("Text");
        textComponent = textGO.GetComponent<Text>();
        buttonA = GameObject.Find("ButtonA");
        buttonB = GameObject.Find("ButtonB");
        buttonC = GameObject.Find("ButtonC");
        manager = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

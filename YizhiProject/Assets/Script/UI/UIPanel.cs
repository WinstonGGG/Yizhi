using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public RawImage charaAImg;
    public RawImage charaBImg;
    public UIPanel contentBg;
    public Text contentTxt;

    public void ShowCharaA(bool value)
    {
        charaAImg.enabled = value;
    }
    public void ShowContentBg(bool value)
    {
        contentBg.enabled = value;
    }
    public void ShowContentText(bool value)
    {
        contentTxt.enabled = value;
    }
    public void SetContentText(string value)
    {
        contentTxt.text = value;
    }
}

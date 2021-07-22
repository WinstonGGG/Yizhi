using UnityEngine;
using TMPro;
using System;

public class EffectManager : MonoBehaviour
{
    public GameObject background, leftChar, rightChar, chatBox, title, content;
    public GameObject resourceLoader;



    public void setTitle(string txt)
    {
        title.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void setContent(string txt)
    {
        content.GetComponent<TextMeshProUGUI>().text = txt;
    }
    public void setBackground(int bgId)
    {
        background.GetComponent<SpriteRenderer>().sprite = resourceLoader.GetComponent<ResourceLoader>().getBackground(bgId);
    }

    public void setChar(string charId)
    {
        if (charId[0] == 'L')
        {
            leftChar.GetComponent<SpriteRenderer>().sprite = resourceLoader.GetComponent<ResourceLoader>().getCharacter(Convert.ToInt32(charId.Substring(1)));
        }
        else if (charId[0] == 'R')
        {
            rightChar.GetComponent<SpriteRenderer>().sprite = resourceLoader.GetComponent<ResourceLoader>().getCharacter(Convert.ToInt32(charId.Substring(1)));
        }
        else
        {
            Debug.Log("输入的角色代码有误");
        }
    }

    public void setChatBoxVisible(bool visible)
    {
        chatBox.SetActive(visible);
    }
}

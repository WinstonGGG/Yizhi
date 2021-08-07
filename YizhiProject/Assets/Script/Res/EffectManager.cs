using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EffectManager : MonoBehaviour
{
    public GameObject background, leftChar, rightChar, chatBox, title, content, options, button;
    public GameObject resourceLoader;

    public int[] jumpLine = new int[4];

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

    public void setOption(string[] optionStr, string[] jumps, int currentLine)
    {
        options.SetActive(true);
        button.SetActive(false);
        for (int i = 0; i < optionStr.Length; i++) {
            options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = optionStr[i];
        }
        for (int i = 0; i < jumps.Length; i++) {
            jumpLine[i] = Convert.ToInt32(jumps[i]) + currentLine;
        }
    }
}

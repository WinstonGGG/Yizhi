using System;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public GameObject textScriptLoader, effectManager;
    public int initTextScript = 0;

    //剧本文件合计，每个string为一行
    private string[,] textScript = new string[20, 100];
    private int currentLine, currentScript;
    public bool needJump = false;
    public int jumpTo = -1;

    //用于检测是否正在演出

    private void Start()
    {
        init();
        playNextLine();
    }

    //初始化
    private void init()
    {
        //因为playNextLine方法会使currentline++，所以初始值设为-1
        currentLine = -1;
        currentScript = initTextScript;
        //读取剧本文件
        for (int i = 0;i < textScriptLoader.GetComponent<TextScriptLoader>().getTextScript().GetLength(0);i++)
        {
            for (int j = 0; j < textScriptLoader.GetComponent<TextScriptLoader>().getTextScript().GetLength(1); j++)
            {
                textScript[i, j] = textScriptLoader.GetComponent<TextScriptLoader>().getTextScript()[i, j];
            }
        }
    }

    public void readScript(int curScirpt)
    {
        needJump = false;
        if(textScript[currentScript, currentLine] != null)
        {
            //读取剧本第一行，设置背景与初始立绘
            if (currentLine == 0)
            {
                string[] headline;
                try
                {
                    headline = textScript[curScirpt, 0].Split('|');
                    setBackGround(Convert.ToInt32(headline[0]));
                    setCharacter(headline[1]);
                    setCharacter(headline[2]);
                }
                catch
                {
                    Debug.Log("第一行读取失败，采用默认设置");
                    setBackGround(0);
                    setCharacter("L0");
                    setCharacter("R0");
                }
                currentLine++;
            }

            //读取正文
            if (currentLine < textScript.GetLength(curScirpt) - 1)
            {
                string[] line;
                // try
                // {
                    line = textScript[curScirpt, currentLine].Split('|');
                    readLine(line);
                // }
                // catch
                // {
                //     Debug.Log("第" + currentLine.ToString() + "行出错，跳过该行");
                // }
            }

            if (textScript[curScirpt, currentLine + 1] == null)
            {
                //检查是否结束
                if (textScript[curScirpt, currentLine] == "*")
                {
                    //在此插入结束后的处理
                }
                else
                {
                    currentScript = Convert.ToInt32(textScript[curScirpt, currentLine]);
                    currentLine = -1;
                }
            }
        }
    }

    private void readLine(string[] line) {
        if (line.Length >= 2)
        {
            //设置说话人与说话内容
            setTitle(line[0]);
            setContent(line[1]);
            if (line.Length > 2)
            {
                int effectCounter = 2;
                while (effectCounter < line.Length)
                {
                    string[] effect = line[effectCounter].Split('：');
                    //效果列表，如需添加新效果则在此增加case
                    switch (effect[0])
                    {
                        case "选项":
                            string[] options = effect[1].Split('/');
                            effectCounter++;
                            string[] jumpLine = line[effectCounter].Split('/');
                            setOptions(options, jumpLine);
                            break;
                        case "背景":
                            setBackGround(Convert.ToInt32(effect[1]));
                            break;
                        case "立绘":
                            setCharacter(effect[1]);
                            break;
                        case "答案跳到":
                            jumpOutOfAnswer(effect[1]);
                            break;
                    }
                    effectCounter++;
                }
            }
        }
        else
        {
            Debug.Log("第" + currentLine.ToString() + "行文本设置不正确，跳过该行");
        }
    }

    private void debugFunction()
    {
        Debug.Log("Not my fault");
    }

    //用于控制文本演出
    public void playNextLine()
    {
        currentLine++;
        readScript(currentScript);
    }

    //用于指定剧本演出; 如果script==-1则在本文件里跳转对话; 如果line==-1则跳转到jumpTo记录的行数
    public void playCertainScript(int script, int line)
    {
        if (script != -1)
            currentScript = script;
        if (line == -1) {
            currentLine = jumpTo;
        }
        else
            currentLine = line;
        readScript(currentScript);
    }

    //根据param的string调整说话者
    private void setTitle(string title)
    {
        effectManager.GetComponent<EffectManager>().setTitle(title);
    }

    //根据param的string调整说话内容
    private void setContent(string content)
    {
        effectManager.GetComponent<EffectManager>().setContent(content);
    }

    //根据param的背景代码设置背景
    private void setBackGround(int bg)
    {
        effectManager.GetComponent<EffectManager>().setBackground(bg);
    }

    //根据param的角色代码设置角色
    private void setCharacter(string ch)
    {
        effectManager.GetComponent<EffectManager>().setChar(ch);
    }

    //根据param的选项显示/隐藏对话框
    private void setChatBoxActive(bool active)
    {
        effectManager.GetComponent<EffectManager>().setChatBoxVisible(active);
    }

    //设置选项
    private void setOptions(string[] options, string[] jumpLine)
    {
        effectManager.GetComponent<EffectManager>().setOption(options, jumpLine, currentLine);
    }

    private void jumpOutOfAnswer(string line) {
        needJump = true;
        jumpTo = currentLine + Convert.ToInt32(line);
        Debug.Log("jump tp: " + jumpTo);
    }
}

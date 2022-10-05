using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    private GameObject panel;//面板
    private Text Text;//文本组件
    private List<(string name,string text)> textList = new List<(string name, string text)>();//对话列表，所有的对话都会加载到这个列表里

    void Start()
    {
        
        instance = this;
        panel = gameObject;
        panel.SetActive(false);
        Text = panel.transform.GetChild(0).GetComponent<Text>();
    }
    void Update()
    {
        //鼠标单击执行下一句，没有则关闭对话框
        if (panel.activeSelf && Input.GetMouseButtonDown(0))
        {
            if(textList.Count > 1)
            {
                textList.RemoveAt(0);
                ShowText(textList[0].name, textList[0].text);
                
            }
/*            else if(textList.Count == 1)
            {
                ShowText(textList[0].name, textList[0].text);
                textList.RemoveAt(0);
            }*/
            else
            {
                HidePanel();
            }
            

        }
    }
    private void HidePanel()
    {
        panel.SetActive(false);
        textList.Clear();
    }

    private void OpenPanel()
    {
        ShowText(textList[0].name, textList[0].text);
        panel.SetActive(true);
    }
    /// <summary>
    /// 设置单句文本
    /// </summary>
    /// <param name="name">名字，对应对话框的文件名</param>
    /// <param name="text">内容</param>
    public void ShowText(string name, string text)
    {
/*        panel.GetComponent<Image>().sprite = Resources.Load("" + name, typeof(Sprite)) as Sprite;*/
        Text.text = name+"  "+text;
    }
    /// <summary>
    /// 设置对话框文本
    /// </summary>
    /// <param name="textlist">文本列表</param>
    public void SetText(List<(string name,string text)> textlist)
    {
        textList = textlist;
        OpenPanel();
    }
    /// <summary>
    /// 设置对话框文本
    /// </summary>
    /// <param name="name">名字，对应对话框的文件名</param>
    /// <param name="text">内容</param>
    public void SetText(string name, string text)
    {
        textList.Add((name,text));
        OpenPanel();
    }
    
}

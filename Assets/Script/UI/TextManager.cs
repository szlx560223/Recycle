using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static TextManager instance;
    private GameObject panel;
    private Text Text;
    private List<(string name,string text)> textList = new List<(string name, string text)>();

    void Start()
    {
        
        instance = this;
        panel = gameObject;
        panel.SetActive(false);
        Text = panel.transform.GetChild(0).GetComponent<Text>();
    }
    void Update()
    {
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
    public void HidePanel()
    {
        panel.SetActive(false);
        textList.Clear();
    }

    public void OpenPanel()
    {
        ShowText(textList[0].name, textList[0].text);
        panel.SetActive(true);
    }

    public void ShowText(string name, string text)
    {
/*        panel.GetComponent<Image>().sprite = Resources.Load("" + name, typeof(Sprite)) as Sprite;*/
        Text.text = name+"  "+text;
    }

    public void SetText(List<(string name,string text)> textlist)
    {
        textList = textlist;
        OpenPanel();
    }
    public void SetText(string name, string text)
    {
        textList.Add((name,text));
        OpenPanel();
    }
    
}

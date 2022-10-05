using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aunt : NPCControl
{

    public int dialogToTrigger = 1;// 即将触发的对话组编号
    bool isInteracted = false;//是否已经交互过
    public List<GameObject> airWalls;//对话后会被解除的空气墙
    /// <summary>
    /// 交互行为
    /// </summary>
    override public void InteractActivity()
    {
        for(int i = 0; i < airWalls.Count; i++)
        {
            if (airWalls.Count == 0) break;
            airWalls[i].gameObject.SetActive(false);
        }
        openDialogPanel();
        isInteracted = true;
    }
    void Update()
    {
        if (!isInteracted)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 打开对话框
    /// </summary>
    void openDialogPanel() {
        if (!isInteracted)
        {
            TextManager.instance.SetText(Texts.instance.GetText(dialogToTrigger));
        }
        else
        {
            TextManager.instance.SetText("aunt", "你还有啥问的吗？年轻人就应该多干点活！");
        }
            
    }

}

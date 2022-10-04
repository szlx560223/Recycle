using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>物品栏的最大数量</summary>
public class PlayerBackpack : MonoBehaviour
{
    private int maxItem = 4;
    List<(String, ItemType)> backpackItem = new List<(String,ItemType)>();
    public static PlayerBackpack instacne;
    [Header("物品栏的父节点")]
    public Transform backpackGUI;
    private Transform[] allSlots;
    // Start is called before the first frame update
    void Start()
    {
        instacne = this;
        allSlots = new Transform[maxItem];
        for (int i = 0; i < maxItem; i++)
            allSlots[i]=backpackGUI.GetChild(i);
    }
    /// <summary>
    /// 向背包里添加物体
    /// </summary>
    /// <param name="other">被添加的物体</param>
    /// <returns>是否添加成功</returns>
    public bool AddToBackpack(GameObject other)
    {
        if (backpackItem.Count >= maxItem) return false;
        (String, ItemType) info = other.GetComponent<Item>().GetInfo();
        backpackItem.Add(info);//加入到背包列表
        other.SetActive(false);
        allSlots[backpackItem.Count-1].gameObject.GetComponent<Image>().sprite = Resources.Load("Texture/Item/" + backpackItem[backpackItem.Count - 1].Item1, typeof(Sprite)) as Sprite;
        return true;
    }
    /// <summary>
    /// 从背包里移除物品
    /// </summary>
    /// <returns>被移除的物品，没有则返回Null</returns>
    public (String,ItemType) RemoveFromBackpack()
    {
        if (isBackpackEmpty()) return("Null",ItemType.Null);
        allSlots[backpackItem.Count - 1].gameObject.GetComponent<Image>().sprite = Resources.Load("Texture/Item/Empty", typeof(Sprite)) as Sprite;
        (String, ItemType) info = getFirstInBackpack();
        backpackItem.RemoveAt(backpackItem.Count - 1);
        return info;
    }
    /// <summary>
    /// 背包是否为空
    /// </summary>
    /// <returns></returns>
    public bool isBackpackEmpty()
    {
        if (backpackItem.Count == 0) return true;
        else return false;  
    }
    /// <summary>
    /// 背包是否已满
    /// </summary>
    /// <returns></returns>
    public bool isBackpackFull()
    {
        if (backpackItem.Count == maxItem) return true;
        else return false;
    }
    /// <summary>
    /// 返回背包里第一个物品
    /// </summary>
    /// <returns>第一个物品（即将被丢出），没有则返回Null</returns>
    public (String, ItemType) getFirstInBackpack()
    {
        if(isBackpackEmpty()) return ("Null", ItemType.Null);
        return backpackItem[backpackItem.Count-1];
    }



}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>物品栏的最大数量</summary>
public class PlayerBackpack : MonoBehaviour
{
    public int maxItem = 3;
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
        if (backpackItem.Count == 0) return("Null",ItemType.Null);
        allSlots[backpackItem.Count - 1].gameObject.GetComponent<Image>().sprite = Resources.Load("Texture/Item/Empty", typeof(Sprite)) as Sprite;
        (String, ItemType) info = backpackItem[backpackItem.Count - 1];
        backpackItem.RemoveAt(backpackItem.Count - 1);
        return info;
    }
    
}


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

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                AddToBackpack(other);
                break;
            default:
                Debug.Log("Unkown trigger");
                break;
        }
    }
    public void AddToBackpack(Collider2D other)
    {
        if (backpackItem.Count >= maxItem) return;
        (String, ItemType) info = other.gameObject.GetComponent<Item>().GetInfo();
        backpackItem.Add(info);//加入到背包列表
        other.gameObject.SetActive(false);
        allSlots[backpackItem.Count-1].gameObject.GetComponent<Image>().sprite = Resources.Load("Texture/Item/" + backpackItem[backpackItem.Count - 1].Item1, typeof(Sprite)) as Sprite;
    }
    public void RemoveFromBackpack()
    {
        if (backpackItem.Count == 0) return;
        allSlots[backpackItem.Count - 1].gameObject.GetComponent<Image>().sprite = Resources.Load("Texture/Item/Empty", typeof(Sprite)) as Sprite;
        backpackItem.RemoveAt(backpackItem.Count - 1);
        
    }
    
}


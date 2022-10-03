using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    List<(String, ItemType)> backpackItem = new List<(String,ItemType)>();
    public static PlayerBackpack instacne;
    // Start is called before the first frame update
    void Start()
    {
        instacne = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            (String, ItemType) info = other.gameObject.GetComponent<Item>().getInfo();
            if (backpackItem.Count > 2) return;
            backpackItem.Add(info);//加入到背包列表
            other.gameObject.SetActive(false);
        }
    }
}


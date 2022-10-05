using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string itemName = "";
    public ItemType itemType = ItemType.Other;

    void Start()
    {
        if (!setTexture()) Debug.Log(itemName + "texture load failed");
    }
    /// <summary>
    /// 设置物品贴图
    /// </summary>
    /// <returns>是否加载成功</returns>
    private bool setTexture()
    {
        string path = "Texture/Item/"+itemName;
        Sprite texture = Resources.Load(path,typeof(Sprite)) as Sprite;
        
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        if (texture == null||render == null) return false;
        render.sprite = texture;
        return true;
    }
    /// <summary>
    /// 返回物品名字，不建议单独使用
    /// </summary>
    /// <returns>物品名字</returns>
    public string getName()
    {
        return itemName;
    }
    /// <summary>
    /// 返回物品类型，不建议单独使用
    /// </summary>
    /// <returns>物品类型</returns>
    public ItemType getType()
    {
        return itemType;
    }
    /// <summary>
    /// 返回物品信息元组
    /// </summary>
    /// <returns>前一个是名字，后一个是类型</returns>
    public (string,ItemType) GetInfo()
    {
        return (itemName,itemType);
    }
}
/// <summary>
/// 垃圾的类型
/// 1.可回收
/// 2.厨余
/// 3.有害
/// 4.其他
/// </summary>
public enum ItemType
{
    Null = 0,
    Recyclable = 1,
    Kitchen = 2,
    Hazardous = 3,
    Other = 4,
}

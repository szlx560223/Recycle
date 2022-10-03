using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    public String itemName = "";
    public ItemType itemType = ItemType.Other;
    public String itemTextureName;

    void Start()
    {
        setTexture();
    }
    /// <summary>
    /// 设置物品贴图，暂时没有用处与实现
    /// </summary>
    /// <returns></returns>
    private bool setTexture()
    {
/*        String path = itemName;
        Resources.Load(path);
        GetComponent<SpriteRenderer>();*/
        return true;
    }
    /// <summary>
    /// 返回物品名字，不建议单独使用
    /// </summary>
    /// <returns>物品名字</returns>
    public String getName()
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
    public (String,ItemType) getInfo()
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
    Recyclable = 1,
    Kitchen = 2,
    Hazardous = 3,
    Other = 4,
}

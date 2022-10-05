using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : NPCControl
{
    public ItemType binType;

    override public void InteractActivity()
    {
        ThrowRubbish();
    }
    /// <summary>
    /// 丢垃圾
    /// </summary>
    /// <returns>是否丢对了垃圾</returns>
    public bool ThrowRubbish()
    {
        if (PlayerBackpack.instacne.isBackpackEmpty()) 
        {
            //Debug.Log("Empty Backpack");
            return false; 
        }
        (string, ItemType) info = PlayerBackpack.instacne.getFirstInBackpack();
        if (isItemTypeMatch(info.Item2))
        {
            ThrowCorrectRubbish();
            return true;
        }
        else
        {
            ThrowWrongRubbish(info);
            return false;
        }
        
    }
    /// <summary>
    /// 丢了正确的垃圾
    /// </summary>
    public void ThrowCorrectRubbish()
    {
        PlayerBackpack.instacne.RemoveFromBackpack();
        //Debug.Log("Throw a correct garbage");
        PlayerControl.instance.pickedGarbageCount++;
    }
    /// <summary>
    /// 丢了错误的垃圾
    /// </summary>
    /// <param name="info">丢的垃圾</param>
    public void ThrowWrongRubbish((string, ItemType) info)
    {
        //Debug.Log("Throw a wrong garbage");
        TextManager.instance.SetText("normal", "这个垃圾不应该放在这里喔,"+info.Item1+"不是"+gameObject.name+"垃圾");
    }
    /// <summary>
    /// 判断垃圾类型是否匹配
    /// </summary>
    /// <param name="itemType">垃圾类型</param>
    /// <returns></returns>
    public bool isItemTypeMatch(ItemType itemType)
    {
        if(itemType==binType) return true;
        return false;   
    }
}
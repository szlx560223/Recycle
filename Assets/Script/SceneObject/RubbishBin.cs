using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : NPCControl
{
    public ItemType binType;

    override public void InteractActivity()
    {
        Debug.Log("Interact with " + gameObject.name + " It's Bin");
        ThrowRubbish();
    }
    public bool ThrowRubbish()
    {
        if (PlayerBackpack.instacne.isBackpackEmpty()) 
        {
            Debug.Log("Empty Backpack");
            return false; 
        }
        (String, ItemType) info = PlayerBackpack.instacne.getFirstInBackpack();
        if (isItemTypeMatch(info.Item2))
        {
            ThrowCorrectRubbish();
            return true;
        }
        else
        {
            ThrowWrongRubbish();
            return false;
        }
        
    }
    public void ThrowCorrectRubbish()
    {
        PlayerBackpack.instacne.RemoveFromBackpack();
        Debug.Log("Throw a correct garbage");
        PlayerControl.instance.pickedGarbageCount++;
    }
    public void ThrowWrongRubbish()
    {
        Debug.Log("Throw a wrong garbage");
    }
    public bool isItemTypeMatch(ItemType itemType)
    {
        if(itemType==binType) return true;
        return false;   
    }
}

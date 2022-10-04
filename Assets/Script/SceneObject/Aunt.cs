using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aunt : NPCControl
{
    override public void InteractActivity()
    {
        Debug.Log("Interact with " + gameObject.name+" It's aunt");

    }
    void openDialogPanel() { 

    }
}

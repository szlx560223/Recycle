using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aunt : NPCControl
{
    public List<GameObject> airWalls;
    override public void InteractActivity()
    {
        Debug.Log("Interact with " + gameObject.name+" It's aunt");
        for(int i = 0; i < airWalls.Count; i++)
        {
            if (airWalls.Count == 0) break;
            airWalls[i].gameObject.SetActive(false);
        }

    }
    void openDialogPanel() { 

    }

}

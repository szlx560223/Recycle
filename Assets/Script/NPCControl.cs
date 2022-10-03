using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }
    /// <summary>
    /// 产生的交互动作
    /// </summary>
    public void InteractActivity()
    {
        Debug.Log("Interact with " + gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    

    public string notice = "那位阿姨看起来在等你和她说话..";// 撞到墙上的提示
    public string name = "normal";
    public bool triggerOnce = false;
    private bool notAgain = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (triggerOnce)
        {
            if (!notAgain)
            {
                TextManager.instance.SetText(name, notice);
            }
            notAgain = true;
        }
        else
        {
            TextManager.instance.SetText(name, notice);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerOnce)
        {
            if (!notAgain)
            {
                TextManager.instance.SetText(name, notice);
            }
            notAgain = true;
        }
        else
        {
            TextManager.instance.SetText(name, notice);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    

    public string notice = "那位阿姨看起来在等你和她说话..";// 撞到墙上的提示
    public bool triggerOnce = false;
    private bool notAgain = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (triggerOnce)
        {
            if (!notAgain)
            {
                TextManager.instance.SetText("normal", notice);
            }
            notAgain = true;
        }
        else
        {
            TextManager.instance.SetText("normal", notice);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerOnce)
        {
            if (!notAgain)
            {
                TextManager.instance.SetText("normal", notice);
            }
            notAgain = true;
        }
        else
        {
            TextManager.instance.SetText("normal", notice);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    public string notice = "那位阿姨看起来在等你和她说话..";
    private void OnCollisionEnter2D(Collision2D other)
    {
        TextManager.instance.SetText("normal", notice);
    }
}

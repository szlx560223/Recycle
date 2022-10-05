using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    public string text1 = "今天的苹果真好吃！该找个地方丢垃圾了。";
    public string text2 = "哪里有丢垃圾的地方呢？去问问前面的那位阿姨吧！";
    void Start()
    {
        TextManager.instance.SetText("self", text1);
        TextManager.instance.SetText("self", text2);
    }


}

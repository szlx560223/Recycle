using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static Texts instance;
    List<(string name, string text)> t0 = new List<(string name, string text)>();
    List<(string name, string text)> t1 = new List<(string name, string text)>();
    List<(string name, string text)> t2 = new List<(string name, string text)>();

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        t0.Add(("normal", "你不应该触发这段对话"));

        t1.Add(("aunt", "小伙子，你是什么垃圾啊？"));
        t1.Add(("self", "啊..？阿..阿姨没事..我还是自己去丢垃圾吧.."));
        t1.Add(("aunt", "行，那你顺带帮我把地上的垃圾捡起来一起丢了吧"));
        t1.Add(("self", "好..."));
        t1.Add(("aunt", "记得把*所有垃圾*分类对喔"));
        t1.Add(("self", "好..."));

        t2.Add(("aunt", "小伙子，你是什么垃圾啊？"));
        t2.Add(("self", "(怎么又来了..)"));
        t2.Add(("self", "没事的阿姨..我自己去丢就可以了.."));
        t2.Add(("aunt", "行，那你顺带帮我把地上的垃圾捡起来一起丢了吧"));
        t2.Add(("self", "（不太情愿）好..."));
        t2.Add(("aunt", "记得把*所有垃圾*分类对喔"));
        t2.Add(("self", "好..."));
    }
    public List<(string name, string text)> GetText(int index)
    {
        List<(string name, string text)> t;
        switch (index)
        {
            case 1:
                t = new List<(string name, string text)>(t1);
                return t;
            case 2:
                t = new List<(string name, string text)>(t2);
                return t;
            default:
                t = new List<(string name, string text)>(t0);
                return t;
        }
    }

}

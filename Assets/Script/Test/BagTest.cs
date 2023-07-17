using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BagTest : MonoBehaviour
{
    [SerializeField] Player bag;


    public void ShowBag()
    {
        Debug.Log("ーーーーーーーーバッグの中身ーーーーーーーー");
        foreach (var pare in bag.getBagSummary())
        {

            Debug.Log(pare.Key  + ":" + pare.Value);

        }
        Debug.Log("ーーーーーーーー");
    }

    public void inItem()
    {
        Debug.Log("カレーを2つバッグに入ました。");
        bag.inItem("#100",2);
    }
    public void inItemISHI()    
    {
        Debug.Log("石の追加");
        bag.inItem("#000", 2);
    }
    public void inItemKI()
    {
        Debug.Log("木の追加");
        bag.inItem("#001", 2);
    }
}



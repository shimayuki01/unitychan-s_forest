using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookExeButton : MonoBehaviour
{
    public static CookExeButton instance;
    public Player player;
    public string itemId;

    void Awake()
    {
        // シングルトンの呪文
        if (instance == null)
        {
            // 自身をインスタンスとする
            instance = this;
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する
            Destroy(gameObject);
        }
    }

    public void exeCook()
    {
        player.Cook(itemId);
    }
}
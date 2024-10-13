using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public static UseItem instance;
    string _useItemId = null;

    // Start is called before the first frame update
    void Start()
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


    public string getUseItem()
    {
        return _useItemId;
    }


    public void setUseItem(string itemId)
    {
        _useItemId = itemId;
        Debug.Log(_useItemId + "を使用アイテムにセットしました");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemPreview : MonoBehaviour
{
    public static BagItemPreview instance;
    [SerializeField] ItemPreview _itemPreview;
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

    public void ShowSelectedItem(string itemId)
    {
        _itemPreview.ShowSelectedItem(itemId,gameObject);
    }


}

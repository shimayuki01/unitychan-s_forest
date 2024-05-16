using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPreview : MonoBehaviour
{
    public static ItemPreview instance;
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

        // アイテム画像の表示
        Image panelImage = gameObject.transform.Find("Image").gameObject.GetComponent<Image>();
        // アイテム画像の取得
        Sprite itemImage = GameData.instance.getItemImage(itemId);
        panelImage.sprite = Instantiate(itemImage);
        // アイテムの透明度を255にして表示する
        panelImage.color = new Color(255, 255, 255, 255);

        // アイテム情報の表示
        string itemInfo;
        Text panelText = gameObject.GetComponentInChildren<Text>();
        itemInfo = "「" +GameData.instance.getAllItem(itemId).name + "」\n" + GameData.instance.getAllItem(itemId).description;
        panelText.text = itemInfo;

    }

}

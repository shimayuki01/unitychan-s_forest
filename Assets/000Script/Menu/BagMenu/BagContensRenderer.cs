using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TNRD;

public class BagContensRenderer : MonoBehaviour
{
    public SerializableInterface<IPlayerBagController> playerBag;

    public void OpenBagPanel(GameObject bagPanel)
    {
        // パネルに表示しているものを空にする
        InitItemPanel(bagPanel);
        // パネルに現在取得しているアイテムを表示する
        DisplayItems(bagPanel, playerBag.Value.getBagSummary());
    }
    public void InitItemPanel(GameObject bagMenuePanel)
    {
        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;
        for (int i = 0; i < 9; i++)
        {
            GameObject itemPanel = itemPanelParent.transform.GetChild(i).gameObject;
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            panelImage.sprite = null;
            panelImage.color = new Color(0, 0, 0, 0);
        }

    }
    public void DisplayItems(GameObject bagMenuePanel, Dictionary<string, int> bagSummary)
    {

        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;
        int idx = 0;
        foreach (var item in bagSummary)
        {
            string itemId = item.Key;
            int item_num = item.Value;


            // パネルの取得
            GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;

            // パネルのスクリプトにitemIdを書き込む
            itemPanel.GetComponent<BagItemPanel>().setItemId(itemId);

            // アイテム画像の表示
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            // アイテム画像の取得
            Sprite itemImage = GameData.instance.getItemImage(itemId);
            panelImage.sprite = Instantiate(itemImage);
            // アイテムの透明度を255にして表示する
            panelImage.color = new Color(255, 255, 255, 255);

            // アイテム個数の表示
            Text panelText = itemPanel.GetComponentInChildren<Text>();
            panelText.text = item_num.ToString();

            idx++;
        }
    }
}

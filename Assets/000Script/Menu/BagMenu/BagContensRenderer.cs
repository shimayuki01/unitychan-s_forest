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
        DisplayItems(bagPanel);
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
    public void DisplayItems(GameObject bagMenuePanel)
    {
        Dictionary<string, int> bagSummary = playerBag.Value.getBagSummary();
        GameObject itemPanelParent = bagMenuePanel.transform.Find("ItemPanel").gameObject;

        
        //使用するアイテムを先頭に表示
        string useItemId = playerBag.Value.getUseItem();
        GameObject itemPanel;
        //バックに入っていないuseItemIdを指定すると何も表示されなくなる(バグ)
        if (useItemId != "")
        {
            // パネルの取得
            itemPanel = itemPanelParent.transform.GetChild(0).gameObject;
            DisplayOneItem(useItemId, bagSummary[useItemId], itemPanel);
            bagSummary.Remove(useItemId);
        }


        int idx = 1;

        foreach (var item in bagSummary)
        {
            string itemId = item.Key;
            int itemNum = item.Value;

            // パネルの取得
            itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;

            DisplayOneItem(itemId, itemNum, itemPanel);

           idx++;
        }
    }

    private void DisplayOneItem(string itemId, int itemNum, GameObject itemPanel)
    {     
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
        panelText.text = itemNum.ToString();
    }
}

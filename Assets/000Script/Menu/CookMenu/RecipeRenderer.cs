using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeRenderer : MonoBehaviour
{
    private CookItem[] _recipeArray;
    private void Start()
    {
        _recipeArray = GameData.instance.getCookItemDataArray();
    }

    public void OpenCookMenu(GameObject cookPanel)
    {
        Debug.Log("Open Cook Menu");
        // パネルに表示しているものを空にする
        InitItemPanel(cookPanel);
        // パネルに現在作成できる料理を表示する
        DisplayItems(cookPanel, _recipeArray);
    }
    public void InitItemPanel(GameObject cookPanel)
    {
        GameObject itemPanelParent = cookPanel.transform.Find("ItemPanel").gameObject;
        for (int i = 0; i < 9; i++)
        {
            GameObject itemPanel = itemPanelParent.transform.GetChild(i).gameObject;
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            panelImage.sprite = null;
            panelImage.color = new Color(0, 0, 0, 0);
        }

    }
    public void DisplayItems(GameObject cookPanel, CookItem[] recipeArray)
    {

        GameObject itemPanelParent = cookPanel.transform.Find("ItemPanel").gameObject;
        int idx = 0;
        Debug.Log("レシピを表示！");
        foreach (CookItem recipe in recipeArray)
        {
            Debug.Log("レシピを表示:" + idx);
            string itemId = recipe.id;

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


            idx++;
        }
    }
}

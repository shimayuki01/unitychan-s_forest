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

    public void PasteRecipe(GameObject cookPanel, Player player)
    {
        Debug.Log("Open Cook Menu");
        // パネルに表示しているものを空にする
        InitItemPanel(cookPanel);
        List<CookItem> cookableItemList = GenerateCookableItemList(player.getBagSummary());
        // パネルに現在作成できる料理を表示する
        DisplayItems(cookPanel, cookableItemList, player);
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
    public void DisplayItems(GameObject cookPanel, List<CookItem> recipeArray, Player player)
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
            itemPanel.GetComponent<CookItemPanel>().setItemId(itemId);

            // アイテム画像の表示
            Image panelImage = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
            // アイテム画像の取得
            Sprite itemImage = GameData.instance.getItemImage(itemId);
            panelImage.sprite = Instantiate(itemImage);
            // アイテムの透明度を255にして表示する
            panelImage.color = new Color(255, 255, 255, 255);


            idx++;
        }


        // 作成ボタンにプレイヤーを持たせる。
        CookExeButton.instance.player = player;
    }

    // 作成可能な料理のリストを作成する
    List<CookItem> GenerateCookableItemList(Dictionary<string, int> playerBagSummary)
    {
        List<CookItem> cookableItemList = new List<CookItem>();
        foreach (CookItem recipe in _recipeArray)
        {
            bool cookable = true;
            // 各素材の個数がバッグの中身より多いか判定する
            foreach (Sozai need_sozai in recipe.sozai)
            {
                
                if (!biggerQuantity(playerBagSummary, need_sozai.id, need_sozai.num))
                {
                    cookable = false;
                }
            }

            // 料理可能なものをリストに追加する
            if (cookable)
            {
                cookableItemList.Add(recipe);
            }

        }

        return cookableItemList;
    }

    bool biggerQuantity(Dictionary<string, int> playerBagSummary, string id, int quantity)
    {
        bool retval = false;
        if (playerBagSummary.ContainsKey(id))
        {
            if (playerBagSummary[id] >= quantity)
            {
                retval =  true;
            }
        }

        return retval;

    }
}

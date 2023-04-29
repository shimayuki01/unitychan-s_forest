using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    Item[] itemDataArray;
    CookItem[] cookItemDataArray;
    Dictionary<string, int> recipe2index;
    Dictionary<int, Item> id2Item;

    // Start is called before the first frame update
    void Start()
    {
        //jsonからデータの読み込み
        itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray().gameItems;
        cookItemDataArray = new JsonReaderFromResourcesFolder().GetRecipe().gameItems;

        //辞書：レシピは配列で管理されてるため、レシピとインデックスを対応させる
        recipe2index = new Dictionary<string, int>();

        foreach (Item item in itemDataArray)
        {
            id2Item.Add(item.id, item);
        }

        for (int i=0; i < cookItemDataArray.Length; i++)
        {
            recipe2index.Add(cookItemDataArray[i].name, i);
        }


    }


    public CookItem getRecipe(string recipe_name)
    {
        if (!recipe2index.ContainsKey(recipe_name)) { Debug.Log(recipe_name + "が見つかりません"); return null; }
        int index = recipe2index[recipe_name];

        return cookItemDataArray[index];
    }

    public CookItem[] getCookItemDataArray()
    {
        return cookItemDataArray;
    }

    public Item getItemFromId(int item_id)
    {
        return id2Item[item_id];
    }
}

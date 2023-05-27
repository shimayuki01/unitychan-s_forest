using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    Item[] itemDataArray;
    CookItem[] cookItemDataArray;
    Dictionary<string, Item> id2Item;
    Dictionary<string, CookItem> id2CookItem;
    Dictionary<string, CookItem> recipeName2item;


    // Start is called before the first frame update
    void Awake()
    {
        //jsonからデータの読み込み
        //レシピ　= [Item 木,Item 石]
        itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray().gameItems;
        //レシピ　= [CookItem カレー,CookItem 肉じゃが]
        cookItemDataArray = new JsonReaderFromResourcesFolder().GetRecipe().gameItems;



        //idとitemの辞書

        //itemの辞書
        id2Item = new Dictionary<string, Item>();
        //CookItemの辞書
        recipeName2item = new Dictionary<string, CookItem>();
        id2CookItem = new Dictionary<string, CookItem>();

        foreach (Item item in itemDataArray)
        {
            id2Item.Add(item.id, item);
        }

        foreach (CookItem item in cookItemDataArray)
        {
            recipeName2item.Add(item.name, item);
        }
        foreach (CookItem item in itemDataArray)
        {
            id2CookItem.Add(item.id, item);
        }
    }

    public Item getItem(string item_id)
    {
        return id2Item[item_id];
    }

    public CookItem[] getCookItemList()
    {
        return cookItemDataArray;
    }
    public CookItem getRecipeFromName(string recipe_name)
    {
        return recipeName2item[recipe_name];
    }

    public CookItem getRecipe(string recipe_id)
    {
        return id2CookItem[recipe_id];
    }

    public CookItem[] getCookItemDataArray()
    {
        return cookItemDataArray;
    }
}

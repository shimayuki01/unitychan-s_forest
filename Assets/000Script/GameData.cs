using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour , ICookItemSozaiAcquisition
{ 
    Item[] itemDataArray;
    CookItem[] cookItemDataArray;
    Dictionary<string, Item> id2Item;
    Dictionary<string, CookItem> id2CookItem;
    Dictionary<string, CookItem> cookItemName2item;


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
        cookItemName2item = new Dictionary<string, CookItem>();
        id2CookItem = new Dictionary<string, CookItem>();

        foreach (Item item in itemDataArray)
        {
            id2Item.Add(item.id, item);
        }

        foreach (CookItem item in cookItemDataArray)
        {
            cookItemName2item.Add(item.name, item);
        }
        foreach (CookItem item in cookItemDataArray)
        {
            id2CookItem.Add(item.id, item);
        }
    }

    public Item getItem(string item_id)
    {
        return id2Item[item_id];
    }
    public CookItem getRecipeFromName(string cookItem_name)
    {
        return cookItemName2item[cookItem_name];
    }

    public CookItem getRecipe(string cookItem_id)
    {
        return id2CookItem[cookItem_id];
    }

    public Sozai[] getCookItemSozai(string cookItem_id)
    {
        return id2CookItem[cookItem_id].sozai;
    }

    public CookItem[] getCookItemDataArray()
    {
        return cookItemDataArray;
    }
}

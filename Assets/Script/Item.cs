using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IAction
{
    delegate void  Use();
}

[System.Serializable]
public class Item :IAction
{
    //木や石など
    public string imgFileName;
    public string name;
    public string description;
    //music SE;
    int heal_amount;


    delegate void Use();


}


//============以下アイテム==================
[System.Serializable]
public class canEatItem
{
    //木や石など
    public string imgFileName;
    public string name;
    public string description;
    //リンゴや木の実


}
[System.Serializable]
public class craftItem :Item
{
// 斧など
    Dictionary<string, int> sozai;
}

[System.Serializable]
public class craftCanEatItem : canEatItem
{
    // 料理
    Dictionary<string, int> sozai;
}


//============以下アイテムArray==================
public class ItemDataArray
{
    public Item[]  gameItems;
}
public class canEatItemDataArray
{
    public canEatItem[] gameItems;
}
public class craftDataArray
{
    public craftItem[]  gameItems;
}
public class craftCanEatItemDataArray
{
    public craftCanEatItem[] gameItems;
}


//============Json読み込み==================

public class JsonReaderFromResourcesFolder
{
    public ItemDataArray GetItemDataArray()
    {
        string filePath = "json/item_list";
        TextAsset file = Resources.Load(filePath) as TextAsset;
        ItemDataArray items = JsonUtility.FromJson<ItemDataArray>(file.text);
        return items;
    }


    public canEatItemDataArray GetRecipe()
    {
        string filePath = "json/recipe";
        TextAsset file = Resources.Load(filePath) as TextAsset;
        canEatItemDataArray items = JsonUtility.FromJson<canEatItemDataArray>(file.text);
        return items;
    }




}

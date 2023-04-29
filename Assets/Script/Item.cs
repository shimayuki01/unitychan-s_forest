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
    public int id;


    delegate void Use();


}


//============以下アイテム==================
[System.Serializable]
public class EatItem : Item
{
    //リンゴや木の実
    //music SE;
    int heal_amount;

}
[System.Serializable]
public class CraftItem :Item
{
// 斧など
    public Dictionary<string, int> sozai;
}

[System.Serializable]
public class CookItem : EatItem
{
    // 料理
    public Sozai[] sozai;
}

[System.Serializable]
public class Sozai
{
    public string name;
    public int num;
}

[System.Serializable]
public class needSozai
{
    public Item item;
    public int num;
}

//カレー　じゃが１人参２
/*
 * json
 * 名前
 * 素材の名前はかけない
 * 素材の数は書きたい
 */


//============以下アイテムArray==================
public class ItemDataArray
{
    public Item[]  gameItems;
}
public class EatItemDataArray
{
    public EatItem[] gameItems;
}
public class CraftDataArray
{
    public CraftItem[]  gameItems;
}
public class CookItemDataArray
{
    public CookItem[] gameItems;
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


    //public EatItemDataArray GetRecipe()
    //{
    //    string filePath = "json/recipe";
    //    TextAsset file = Resources.Load(filePath) as TextAsset;
    //    EatItemDataArray items = JsonUtility.FromJson<EatItemDataArray>(file.text);
    //    return items;
    //}

    public CookItemDataArray GetRecipe()
    {
        string filePath = "json/recipe";
        TextAsset file = Resources.Load(filePath) as TextAsset;
        CookItemDataArray items = JsonUtility.FromJson<CookItemDataArray>(file.text);
        return items;
    }




}

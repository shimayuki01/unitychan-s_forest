using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IAction
{
    delegate void  Use();
}

[System.Serializable]
public class Item
{
    //木や石など
    public string imgFileName;
    public string name;
    public string description;
    //music SE;
    delegate void use();


}
class canEatItem :Item
{
   //リンゴや木の実
    int heal_amount;
}

class craftItem :Item
{
// 斧など
    Dictionary<string, int> sozai;
}

class craftCanEatItem :canEatItem
{
    // 料理
    Dictionary<string, int> sozai;
}
public class ItemDataArray
{
    public Item[]  gameItems;
}

public class JsonReaderFromResourcesFolder
{
    public ItemDataArray GetItemDataArray()
    {
        string filePath = "json/item_list";
        TextAsset file = Resources.Load(filePath) as TextAsset;
        ItemDataArray items = JsonUtility.FromJson<ItemDataArray>(file.text);
        return items;
    }
}

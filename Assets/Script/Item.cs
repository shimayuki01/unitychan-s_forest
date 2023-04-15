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
    //�؂�΂Ȃ�
    public string imgFileName;
    public string name;
    public string description;
    //music SE;
    int heal_amount;


    delegate void Use();


}


//============�ȉ��A�C�e��==================
[System.Serializable]
public class canEatItem
{
    //�؂�΂Ȃ�
    public string imgFileName;
    public string name;
    public string description;
    //�����S��؂̎�


}
[System.Serializable]
public class craftItem :Item
{
// ���Ȃ�
    Dictionary<string, int> sozai;
}

[System.Serializable]
public class craftCanEatItem : canEatItem
{
    // ����
    Dictionary<string, int> sozai;
}


//============�ȉ��A�C�e��Array==================
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


//============Json�ǂݍ���==================

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

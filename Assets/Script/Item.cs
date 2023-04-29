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
    public int id;


    delegate void Use();


}


//============�ȉ��A�C�e��==================
[System.Serializable]
public class EatItem : Item
{
    //�����S��؂̎�
    //music SE;
    int heal_amount;

}
[System.Serializable]
public class CraftItem :Item
{
// ���Ȃ�
    public Dictionary<string, int> sozai;
}

[System.Serializable]
public class CookItem : EatItem
{
    // ����
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

//�J���[�@���Ⴊ�P�l�Q�Q
/*
 * json
 * ���O
 * �f�ނ̖��O�͂����Ȃ�
 * �f�ނ̐��͏�������
 */


//============�ȉ��A�C�e��Array==================
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

using System.Collections;
using System.Collections.Generic;
interface IAction
{
    delegate void  Use();
}

public class Item
{
    //木や石など
    string imgFileName;
    string name;
    string description;
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
class ItemDataArray
{
    Item[]  gameItems;
}

class JsonReaderFromResourcesFolder
{
    delegate ItemDataArray GetItemDataArray();
}

using System.Collections;
using System.Collections.Generic;
interface IAction
{
    delegate void  Use();
}

public class Item
{
    //�؂�΂Ȃ�
    string imgFileName;
    string name;
    string description;
    //music SE;
    delegate void use();

}
class canEatItem :Item
{
   //�����S��؂̎�
    int heal_amount;
}

class craftItem :Item
{
// ���Ȃ�
    Dictionary<string, int> sozai;
}

class craftCanEatItem :canEatItem
{
    // ����
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

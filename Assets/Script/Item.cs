using System.Collections;
using System.Collections.Generic;
interface IAction
{
    delegate void  Use();
}

public class Item
{
    //–Ø‚âÎ‚È‚Ç
    string imgFileName;
    string name;
    string description;
    //music SE;
    delegate void use();

}
class canEatItem :Item
{
   //ƒŠƒ“ƒS‚â–Ø‚ÌÀ
    int heal_amount;
}

class craftItem :Item
{
// •€‚È‚Ç
    Dictionary<string, int> sozai;
}

class craftCanEatItem :canEatItem
{
    // —¿—
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

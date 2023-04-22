using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Ono playerOno = new Ono(1, 1);
    Bag playerBag = new Bag();
    Item apple = new Item();
    Dictionary<string, int> sozai = new Dictionary<string, int>();



    private void Start()
    {
        sozai.Add("ジャガイモ", 2);
        sozai.Add("ニンジン", 1);
        sozai.Add("豚肉", 3);
        //ここに書かない、後でちゃんしたクラスに書く
        ItemDataArray itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray();
        CookItemDataArray itemDataArray2 = new JsonReaderFromResourcesFolder().GetRecipe();

        Debug.Log("itemDataArray: " + itemDataArray.gameItems[0].name);
        Debug.Log("itemDataArray: " + itemDataArray2.gameItems[0].name);
        Debug.Log("sozai: " + itemDataArray2.gameItems[0].sozai[0].name);
        foreach (var kp in sozai)
        {
            var key = kp.Key;
            var value = kp.Value;
            Debug.Log($"{key} / {value}");
        }




        apple.name = "リンゴ";
        apple.description = "a";
        apple.imgFileName = "a";
        playerBag.inItem(apple, 1); 
        Debug.Log("BagSummary" + getBagSummary()[apple]);




    }

    public int getPlayerOnoLv(){ return playerOno.getLv();}

    public int getPlayerOnoAtk() { return playerOno.getAtk(); }

    public Dictionary<Item, int> getBagSummary(){ return this.playerBag.getSummary();  }
}

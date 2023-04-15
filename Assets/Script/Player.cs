using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Ono playerOno = new Ono(1, 1);
    Bag playerBag = new Bag();
    Item apple = new Item();



    private void Start()
    {
        //Ç±Ç±Ç…èëÇ©Ç»Ç¢ÅAå„Ç≈ÇøÇ·ÇÒÇµÇΩÉNÉâÉXÇ…èëÇ≠
        ItemDataArray itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray();
        canEatItemDataArray itemDataArray2 = new JsonReaderFromResourcesFolder().GetRecipe();

        Debug.Log("itemDataArray: " + itemDataArray.gameItems[0].name);
        Debug.Log("itemDataArray: " + itemDataArray.gameItems[1].name);
        Debug.Log("itemDataArray: " + itemDataArray2.gameItems[0].name);





        apple.name = "ÉäÉìÉS";
        apple.description = "a";
        apple.imgFileName = "a";
        playerBag.inItem(apple, 1); 
        Debug.Log("BagSummary" + getBagSummary()[apple]);




    }

    public int getPlayerOnoLv(){ return playerOno.getLv();}

    public int getPlayerOnoAtk() { return playerOno.getAtk(); }

    public Dictionary<Item, int> getBagSummary(){ return this.playerBag.getSummary();  }
}

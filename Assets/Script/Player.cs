using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ono playerOno = new Ono(1, 1);
    Bag playerBag = new Bag();

    private void Start()
    {
        ItemDataArray itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray();

        Debug.Log("itemDataArray: " + itemDataArray.gameItems[0].name);
        Debug.Log("itemDataArray: " + itemDataArray.gameItems[1].name);
    }

    public int getPlayerOnoLv(){ return playerOno.getLv();}

    public int getPlayerOnoAtk() { return playerOno.getAtk(); }

    public Dictionary<Item, int> getBagSummary(){ return this.playerBag.getSummary();  }
}

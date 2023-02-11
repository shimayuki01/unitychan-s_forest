using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ono playerOno = new Ono(1, 1);
    Bag playerBag = new Bag();

    public int getPlayerOnoLv(){ return playerOno.getLv();}

    public int getPlayerOnoAtk() { return playerOno.getAtk(); }

    public Dictionary<Item, int> getBagSummary(){ return this.playerBag.getSummary();  }
}

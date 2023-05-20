using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Ono playerOno = new Ono(1, 1);
    Bag playerBag = new Bag();



    private void Start()
    {

    }

    public int getPlayerOnoLv(){ return playerOno.getLv();}

    public int getPlayerOnoAtk() { return playerOno.getAtk(); }

    public Bag getPlayerBag() { return playerBag; }

    public Dictionary<string, int> getBagSummary(){ return this.playerBag.getSummary();  }
}

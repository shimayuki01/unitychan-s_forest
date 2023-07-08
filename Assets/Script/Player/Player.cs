using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Ono _ono = new Ono(1, 1);
    GameData gamedata = new GameData();
    IManager _manager;



    private void Start()
    {
        _manager = new Cook(gamedata);
    }

    public int getPlayerOnoLv(){ return _ono.getLv();}

    public int getPlayerOnoAtk() { return _ono.getAtk(); }

    public Dictionary<string, int> getBagSummary(){ return this._manager.getBagSummary();  }
}

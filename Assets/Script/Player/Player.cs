using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    Ono _ono = new Ono(1, 1);
    [SerializeField] GameData gamedata;
    IManager _manager;



    private void Start()
    {
        _manager = new Cook(gamedata);
    }
    public void inItem(string id, int quantity)
    {
        _manager.pickUpItem(id, quantity);
    }

    public void Cook(string cookItem_id)
    {
        _manager.doCook(cookItem_id);
    }

    public void Walk(Vector2 walkVector)
    {
        Debug.Log("ï‡Ç≠ï˚å¸ÅF"+walkVector);
    }

    public int getPlayerOnoLv(){ return _ono.getLv();}

    public int getPlayerOnoAtk() { return _ono.getAtk(); }

    public Dictionary<string, int> getBagSummary(){ return this._manager.getBagSummary();  }
}

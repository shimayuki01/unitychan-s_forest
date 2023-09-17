using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAction : MonoBehaviour
{
    [SerializeField] Player _player;
    public void Cook(string cookItem_id)
    {
        // クックできるかの確認
        _player.Cook(cookItem_id);
    }

    public void Walk(Vector2 walkVector)
    {
        // 歩く処理
        _player.Walk(walkVector);
    }
}

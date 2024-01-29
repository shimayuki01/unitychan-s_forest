using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteAction : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Button _actionButton;
    public void Cook(string cookItem_id)
    {
        // TODO:クックできるかの確認
        _player.Cook(cookItem_id);
    }

    public void Walk(Vector2 walkVector)
    {
        // 歩く処理
        _player.Walk(walkVector);
    }

    public void action()
    {
        _actionButton.onClick.Invoke();
    }
}

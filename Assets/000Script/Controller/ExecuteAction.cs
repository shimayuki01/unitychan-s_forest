using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteAction : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Button _actionButton;
    [SerializeField] BaseMenuPanel _baseMenuPanel;
    [SerializeField] GameObject _bagPanel;
    [SerializeField] BagContensRenderer _bagContensRenderer;

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

    public void closePanel()
    {
        _baseMenuPanel.CloseButtonClicked();
    }

    public void openBag()
    {
        foreach (var i in _player.getBagSummary())
        {
            Debug.Log(i.Key + " " + i.Value);
        }

        _baseMenuPanel.InstiatePanel(_bagPanel);
        Dictionary<string, int> bagSummary = _player.getBagSummary();
        _bagContensRenderer.DisplayItems(_bagPanel, bagSummary);

    }
}

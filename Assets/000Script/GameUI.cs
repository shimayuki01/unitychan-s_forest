using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IGameUI
{
    [SerializeField] Button _actionButton;

    [SerializeField] GameObject _bagPanel;
    [SerializeField] BaseMenuPanel _baseMenuPanel;
    [SerializeField] BagContensRenderer _bagContensRenderer;
    //    Dictionary<string, int> bagSummary = _player.getBagSummary();

    public void Contact()
    {
        _actionButton.onClick.Invoke();
    }
    public void OpenBag()
    {
        _baseMenuPanel.InstiatePanel(_bagPanel);
        _bagContensRenderer.OpenBagPanel(_baseMenuPanel._panelInstance);
    }
}

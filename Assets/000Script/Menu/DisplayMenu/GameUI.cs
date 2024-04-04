using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IGameUI
{
    [SerializeField] Button _actionButton;

    [SerializeField] GameObject _bagPanel;
    [SerializeField] MenuPanelManager _menuPanelManager;
    [SerializeField] BagContensRenderer _bagContensRenderer;

    public void Contact()
    {
        _actionButton.onClick.Invoke();
    }
    public void OpenBag()
    {
        // パネルの作成
        GameObject _panelInstance = _menuPanelManager.InstiatePanel(_bagPanel);
        // パネルに現在所持しているアイテムを表示する
        _bagContensRenderer.OpenBagPanel(_panelInstance);
    }
}

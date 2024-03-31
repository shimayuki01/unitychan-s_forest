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

    public void Contact()
    {
        _actionButton.onClick.Invoke();
    }
    public void OpenBag()
    {
        // �p�l���̍쐬
        GameObject _panelInstance = _baseMenuPanel.InstiatePanel(_bagPanel);
        // �p�l���Ɍ��ݏ������Ă���A�C�e����\������
        _bagContensRenderer.OpenBagPanel(_panelInstance);
    }
}
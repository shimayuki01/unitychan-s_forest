using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CraftTrigger : MonoBehaviour
{
    private bool isInCraftArea = false;
    public Sprite craftButtonImage;
    [SerializeField] Button _actionButton;
    [SerializeField] RegisterAction registerAction;
    [SerializeField] GameObject _craftPanelPrefab;
    [SerializeField] MenuPanelManager _menuPanelManager;

    //public GameObject _craftPanelInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInCraftArea = true;
            _actionButton.gameObject.SetActive(true);
            _actionButton.image.sprite = craftButtonImage;
            _actionButton.onClick.AddListener(OpenCraftPanel);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInCraftArea = false;
            _actionButton.image.sprite = null;
            _actionButton.onClick.RemoveListener(OpenCraftPanel);
        }
    }


    void OpenCraftPanel()
    {
        _menuPanelManager.InstiatePanel(_craftPanelPrefab);
    }

}

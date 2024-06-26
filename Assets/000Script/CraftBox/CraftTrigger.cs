using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CraftTrigger : MonoBehaviour
{
    public Sprite craftButtonImage;
    [SerializeField] Button _actionButton;
    [SerializeField] GameObject _craftPanelPrefab;
    [SerializeField] MenuPanelManager _menuPanelManager;

    //public GameObject _craftPanelInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _actionButton.gameObject.SetActive(true);
            _actionButton.image.sprite = craftButtonImage;
            _actionButton.onClick.AddListener(OpenCraftPanel);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _actionButton.gameObject.SetActive(false);
            _actionButton.image.sprite = null;
            _actionButton.onClick.RemoveListener(OpenCraftPanel);
        }
    }


    void OpenCraftPanel()
    {
        _menuPanelManager.InstiateManuPanel(_craftPanelPrefab);
        gameObject.GetComponent<RecipeRenderer>().OpenCookMenu(_menuPanelManager.getManuPanelInstance());
    }

}

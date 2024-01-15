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
    public GameObject _craftPanelInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("��������!");
            isInCraftArea = true;
            _actionButton.onClick.AddListener(comment);
            _actionButton.gameObject.SetActive(true);
            _actionButton.image.sprite = craftButtonImage;
            _actionButton.onClick.AddListener(OpenCraftPanel);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("���ꂽ!");
            isInCraftArea = false;
            _actionButton.onClick.RemoveListener(OpenCraftPanel);
        }
    }


    void OpenCraftPanel()
    {
        if ( _craftPanelInstance == null)
        {
            //Debug.Log("�v���n�u����");
            //Debug.Log("�v���n�u����");
            //������ďd��������h��
            _craftPanelInstance = Instantiate(_craftPanelPrefab);
            //Time.timeScale = 0f;
        }
    }
}

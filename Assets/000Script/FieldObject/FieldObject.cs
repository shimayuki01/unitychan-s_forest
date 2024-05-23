using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldObject : MonoBehaviour
{
    public Sprite _buttonImage;
    [SerializeField] Button _actionButton;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _actionButton.gameObject.SetActive(true);
            _actionButton.image.sprite = _buttonImage;
            // _actionButton.onClick.AddListener();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _actionButton.gameObject.SetActive(false);
            _actionButton.image.sprite = null;
            // _actionButton.onClick.RemoveListener();
        }
    }
}

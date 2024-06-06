using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class FieldObject : MonoBehaviour
{

    public Button contactButton;
    public string itemId;
    private Sprite _buttonImage;

    private void Start()
    {
        _buttonImage = GameData.instance.getItemImage(itemId);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            contactButton.gameObject.SetActive(true);
            _buttonImage = GameData.instance.getItemImage(itemId);
            contactButton.image.sprite = _buttonImage;
            contactButton.onClick.AddListener(() => pickUpItem(other.gameObject.GetComponent<Player>()));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            contactButton.gameObject.SetActive(false);
            contactButton.image.sprite = null;
            contactButton.onClick.RemoveAllListeners();
        }
    }


    void pickUpItem(Player player)
    {
        player.inItem(itemId);
        Destroy(gameObject);
        contactButton.gameObject.SetActive(false);
        contactButton.image.sprite = null;
        contactButton.onClick.RemoveAllListeners();
    }
}

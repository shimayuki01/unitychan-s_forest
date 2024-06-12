using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class FieldObject : MonoBehaviour
{

    public Button contactButton;
    public string itemId;
    private Sprite _fieldObjectImage;

    void OnTriggerEnter(Collider other)
    {
        if (!_fieldObjectImage)
        {
            _fieldObjectImage = GameData.instance.getItemImage(itemId);
        }
        if (other.tag == "Player")
        {
            contactButton.gameObject.SetActive(true);
            contactButton.image.sprite = _fieldObjectImage;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldObject : MonoBehaviour
{

    [SerializeField] Button _contactButton;
    public string _itemId;
    private Sprite _buttonImage;

    private void Start()
    {
        _buttonImage = GameData.instance.getItemImage(_itemId);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _contactButton.gameObject.SetActive(true);
            _buttonImage = GameData.instance.getItemImage(_itemId);
            _contactButton.image.sprite = _buttonImage;
            _contactButton.onClick.AddListener(() => pickUpItem(other.gameObject.GetComponent<Player>()));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _contactButton.gameObject.SetActive(false);
            _contactButton.image.sprite = null;
            _contactButton.onClick.RemoveAllListeners();
        }
    }


    void pickUpItem(Player player)
    {
        player.inItem(_itemId);
        Destroy(gameObject);
        _contactButton.gameObject.SetActive(false);
        _contactButton.image.sprite = null;
        _contactButton.onClick.RemoveAllListeners();
    }
}

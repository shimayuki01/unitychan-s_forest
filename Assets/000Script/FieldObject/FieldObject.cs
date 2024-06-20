using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshCollider))]
public class FieldObject : MonoBehaviour
{

    public string itemId;
    public Sprite fieldObjectImage;

    void OnTriggerEnter(Collider other)
    {
        //�A�C�e���摜���擾
        if (!fieldObjectImage)
        {
            fieldObjectImage = GameData.instance.getItemImage(itemId);
        }

        //�R���^�N�g�{�^���̍X�V
        if (other.tag == "Player")
        {
            Debug.Log("���X�g�ɒǉ�" +gameObject.name);
            FieldObjectPickupManager.instance.UpdateContactButton(gameObject, other.gameObject.GetComponent<Player>(), true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("���X�g����폜" + gameObject.name);

            FieldObjectPickupManager.instance.UpdateContactButton(gameObject, other.gameObject.GetComponent<Player>(), false);
        }
    }


    public void pickUpItem(Player player)
    {
        Debug.Log("���X�g����폜" + gameObject.name);
        player.inItem(itemId);
        FieldObjectPickupManager.instance.UpdateContactButton(gameObject, player, false);
        Destroy(gameObject);

    }
}

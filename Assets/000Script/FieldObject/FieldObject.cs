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
        //アイテム画像を取得
        if (!fieldObjectImage)
        {
            fieldObjectImage = GameData.instance.getItemImage(itemId);
        }

        //コンタクトボタンの更新
        if (other.tag == "Player")
        {
            Debug.Log("リストに追加" +gameObject.name);
            FieldObjectPickupManager.instance.UpdateContactButton(gameObject, other.gameObject.GetComponent<Player>(), true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("リストから削除" + gameObject.name);

            FieldObjectPickupManager.instance.UpdateContactButton(gameObject, other.gameObject.GetComponent<Player>(), false);
        }
    }


    public void pickUpItem(Player player)
    {
        Debug.Log("リストから削除" + gameObject.name);
        player.inItem(itemId);
        FieldObjectPickupManager.instance.UpdateContactButton(gameObject, player, false);
        Destroy(gameObject);

    }
}

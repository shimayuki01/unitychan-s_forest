using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldObjectPickupManager : MonoBehaviour
{
    public static FieldObjectPickupManager instance; // �C���X�^���X�̒�`

    public List<GameObject> pickupItemList { get; private set; } = new List<GameObject>();
    //[SerializeField] Player player;
    public bool isItemListUpdate = true;
    public Button contactButton;

    void Start()
    {    
        // �V���O���g���̎���
        if (instance == null)
        {
            // ���g���C���X�^���X�Ƃ���
            instance = this;
        }
        else
        {
            // �C���X�^���X���������݂��Ȃ��悤�ɁA���ɑ��݂��Ă����玩�g����������
            Destroy(gameObject);
        }

    }


    private void PickUpNearItemFirst(Player player)
    {
        if (pickupItemList.Count <= 1) return;
        Vector3 playerPos = player.transform.position;
        // �����ŏ��l��ݒ�
        float minDirection = Vector3.Distance(pickupItemList[0].transform.position, playerPos);
        // ��ڂ̃A�C�e������擾�|�C���g�Ƃ̋������v�Z
        for (int itemNum = 1; itemNum < pickupItemList.Count; itemNum++)
        {
            float direction = Vector3.Distance(pickupItemList[itemNum].transform.position, playerPos);
            // ���߂��I�u�W�F�N�g��0�Ԗڂ̗v�f�ɑ��
            if (minDirection > direction)
            {
                minDirection = direction;
                var temp = pickupItemList[0];
                pickupItemList[0] = pickupItemList[itemNum];
                pickupItemList[itemNum] = temp;
            }
        }
    }

    private void SetupContactButton(FieldObject attachItem, Player player)
    {
        contactButton.onClick.RemoveAllListeners();
        contactButton.gameObject.SetActive(true);
        contactButton.image.sprite = attachItem.fieldObjectImage;
        contactButton.onClick.AddListener(() => attachItem.pickUpItem(player));
    }

    public void UpdateContactButton(GameObject contactItem, Player player, bool isIncrease)
    {

        if (isIncrease)
        {
            pickupItemList.Add(contactItem);
        }
        else
        {
            pickupItemList.Remove(contactItem);
        }
        Debug.Log("�A�C�e���ꗗ������");
        foreach(GameObject game in pickupItemList)
        {
            Debug.Log("--"+game.name);
        }
        Debug.Log("������=======================");

        if (pickupItemList.Count > 0)
        {
            PickUpNearItemFirst(player);
            GameObject _nearItem = pickupItemList[0];
            SetupContactButton(_nearItem.GetComponent<FieldObject>(), player);
        }
        else
        {
            contactButton.gameObject.SetActive(false);
            contactButton.image.sprite = null;
            contactButton.onClick.RemoveAllListeners();
        }

        

    }







}

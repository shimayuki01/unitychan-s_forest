using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemPreview : MonoBehaviour
{
    public static BagItemPreview instance;
    [SerializeField] ItemPreview _itemPreview;
    // Start is called before the first frame update
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

    public void ShowSelectedItem(string itemId)
    {
        _itemPreview.ShowSelectedItem(itemId,gameObject);
    }


}

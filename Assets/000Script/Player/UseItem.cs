using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public static UseItem instance;
    string _useItemId = null;

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


    public string getUseItem()
    {
        return _useItemId;
    }


    public void setUseItem(string itemId)
    {
        _useItemId = itemId;
        Debug.Log(_useItemId + "���g�p�A�C�e���ɃZ�b�g���܂���");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookExeButton : MonoBehaviour
{
    public static CookExeButton instance;
    public Player player;
    public string itemId;

    void Awake()
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

    public void exeCook()
    {
        player.Cook(itemId);
    }
}
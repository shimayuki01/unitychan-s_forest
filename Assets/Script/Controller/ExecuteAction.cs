using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteAction : MonoBehaviour
{
    [SerializeField] Player _player;
    public void Cook(string cookItem_id)
    {
        // �N�b�N�ł��邩�̊m�F
        _player.Cook(cookItem_id);
    }

    public void Walk(Vector2 walkVector)
    {
        // ��������
        _player.Walk(walkVector);
    }
}

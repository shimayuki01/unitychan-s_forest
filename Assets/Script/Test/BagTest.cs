using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
    Bag bag;

    private void Start()
    {
        bag = new Bag();
        cook = new Cook(gamedata);

    }
    GameData gamedata = new GameData();

    Cook cook;

    public void Cook()
    {
        //cook.remakeCanCookItemsList(player.getPlayerBag());
        cook.doCook("#100");
        Debug.Log("�N�b�N���܂����B");
    }

    public void ShowBag()
    {
        Debug.Log("�[�[�[�[�[�[�[�[�o�b�O�̒��g�[�[�[�[�[�[�[�[");
        foreach (var pare in bag.getBagSummary())
        {

            Debug.Log(pare.Key  + ":" + pare.Value);

        }
        Debug.Log("�[�[�[�[�[�[�[�[");
    }

    public void inItem()
    {
        Debug.Log("�J���[��2�o�b�O�ɓ��܂����B");
        bag.inItem("#100",2);
    }
    public void inItemISHI()
    {
        Debug.Log("�΂̒ǉ�");
        bag.inItem("#000", 2);
    }
    public void inItemKI()
    {
        Debug.Log("�؂̒ǉ�");
        bag.inItem("#001", 2);
    }
}



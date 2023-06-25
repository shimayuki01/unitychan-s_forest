using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������
public class Cook : MonoBehaviour, IManager
{
    // Start is called before the first frame update
    [SerializeField] GameData _gameData;
    CookItem[] _cookItems;
    public List<string> _canCookItems;
    [SerializeField] IItemConsumption _bag;
    ICookItemSozaiAcquisition _cookItemSozaiAcquisition;


    void Start()
    {
        _cookItems = _gameData.getCookItemDataArray();
        _canCookItems = new List<string>();
        _cookItemSozaiAcquisition = new GameData(); 

    }
    //�����\���X�g�̐���(�����͂߂��Ⴍ���ራ��)
    public void remakeCanCookItemsList(Bag _player_bag)
    {
        _canCookItems.Clear();

        foreach(CookItem cookItem in _cookItems)
        {
            if (canCook(cookItem.id, _player_bag))
                _canCookItems.Add(cookItem.id);
        }
    }



    //�o�b�N���̍ޗ��ŗ������ł��邩�m�F����
    bool canCook(string recipe_id, Bag _player_bag)
    {
        //���V�s�̏����Ђς��Ă���
        CookItem recipe_data = _gameData.getRecipe(recipe_id);

        //�o�b�O�ɑf�ނ������Ă��邩�̊m�F
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            if (_player_bag.getBagSummary()[need_sozai.id] < need_sozai.num)
            {
                Debug.Log("�����ł��Ȃ�");
                return false;
            }
        }

        return true;

    }

    //�o�b�N�̍ޗ�������ė������o�b�N�ɒǉ�
    public void doCook(string cookItem_id)
    {
        //���V�s�̏����Ђς��Ă���
        Sozai[] sozais = _cookItemSozaiAcquisition.getCookItemSozai(cookItem_id);

        //�o�b�N����f�ނ�����(���m�F��canCook�ōs��)
        foreach (Sozai need_sozai in sozais)
        {
            _bag.deleteItem(need_sozai.id, need_sozai.num);
        }

        //����͂܂Ƃ߂Ē����ł��Ȃ��̂Œ������cook_item�͈��
        _bag.inItem(cookItem_id, 1);

    }
}

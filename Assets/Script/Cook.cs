using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������
public class Cook : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameData _gameData;
    CookItem[] _cookItems;
    public List<string> _canCookItems;


    void Start()
    {
        _cookItems = _gameData.getCookItemDataArray();
        _canCookItems = new List<string>();

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
            if (_player_bag.getSummary()[need_sozai.id] < need_sozai.num)
            {
                Debug.Log("�����ł��Ȃ�");
                return false;
            }
        }

        return true;

    }

    //�o�b�N�̍ޗ�������ė������o�b�N�ɒǉ�
    public void doCook(string recipe_id, Bag _player_bag)
    {
        //���V�s�̏����Ђς��Ă���
        CookItem recipe_data = _gameData.getRecipe(recipe_id);

        //�o�b�N����f�ނ�����(���m�F��canCook�ōs��)
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            Item item = _gameData.getItem(need_sozai.id);
            _player_bag.deleteItem(item.id, need_sozai.num);
        }

        //����͂܂Ƃ߂Ē����ł��Ȃ��̂Œ������cook_item�͈��
        _player_bag.inItem(recipe_id, 1);

    }
}

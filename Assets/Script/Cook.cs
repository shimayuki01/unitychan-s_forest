using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//料理が
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
    //料理可能リストの生成(効率はめちゃくちゃ悪い)
    public void remakeCanCookItemsList(Bag _player_bag)
    {
        _canCookItems.Clear();

        foreach(CookItem cookItem in _cookItems)
        {
            if (canCook(cookItem.id, _player_bag))
                _canCookItems.Add(cookItem.id);
        }
    }



    //バック内の材料で料理ができるか確認する
    bool canCook(string recipe_id, Bag _player_bag)
    {
        //レシピの情報をひぱってくる
        CookItem recipe_data = _gameData.getRecipe(recipe_id);

        //バッグに素材が入っているかの確認
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            if (_player_bag.getSummary()[need_sozai.id] < need_sozai.num)
            {
                Debug.Log("調理できない");
                return false;
            }
        }

        return true;

    }

    //バックの材料を消費して料理をバックに追加
    public void doCook(string recipe_id, Bag _player_bag)
    {
        //レシピの情報をひぱってくる
        CookItem recipe_data = _gameData.getRecipe(recipe_id);

        //バックから素材を引く(個数確認はcanCookで行う)
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            Item item = _gameData.getItem(need_sozai.id);
            _player_bag.deleteItem(item.id, need_sozai.num);
        }

        //現状はまとめて調理できないので調理後のcook_itemは一つ
        _player_bag.inItem(recipe_id, 1);

    }
}

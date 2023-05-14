using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craft : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player player;
    [SerializeField] GameData gameData;

    void Start()
    {
        Debug.Log("BagSummary"+player.getBagSummary());

        CookItem kare = gameData.getRecipe("肉じゃが");
        Debug.Log("kare-" + kare.name);
        //Cook(kare, player.getPlayerBag());

    }

    //バックの管理をIDで処理するようにしてから再度
    bool canCook(CookItem cook_item, Bag player_bag)
    {
        //レシピの情報をひぱってくる
        //CookItem recipe_data = gameData.getRecipe(recipe_name);

        //バッグに素材が入っているかの確認
        //foreach(Sozai need_sozai in cook_item.sozai) 
        //{
        //    Item item = gameData.getItemFromId(need_sozai.id);
        //    if (player_bag.getSummary()[item] < need_sozai.num)
        //    {
        //        Debug.Log("調理できない");
        //        return false;
        //    }
        //}

        return true;
        
    }

    void Cook(CookItem cook_item, Bag player_bag)
    {
        //レシピの情報をひぱってくる
        //CookItem recipe_data = gameData.getRecipe(recipe_name);

        //バックから素材を引く(個数確認はcanCookで行う)
        foreach (Sozai need_sozai in cook_item.sozai)
        {
            Item item = gameData.getItemFromId(need_sozai.id);
            player_bag.deleteItem(item, need_sozai.num);
        }

        //現状はまとめて調理できないので調理後のcook_itemは一つ
        player_bag.inItem(cook_item, 1);

    }
}

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

        //CookItem kare = gameData.getRecipe("肉じゃが");
        //Debug.Log("kare-" + kare.name);
        //Cook(kare, player.getPlayerBag());

    }

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

   
    void Cook(string recipe_id, Bag player_bag)
    {
        //レシピの情報をひぱってくる
        CookItem recipe_data = gameData.getRecipe(recipe_id);

        //バックから素材を引く(個数確認はcanCookで行う)
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            Item item = gameData.getItem(need_sozai.id);
            player_bag.deleteItem(item.id, need_sozai.num);
        }

        //現状はまとめて調理できないので調理後のcook_itemは一つ
        player_bag.inItem(recipe_id, 1);

    }
}

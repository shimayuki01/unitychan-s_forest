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

        CookItem kare = gameData.getRecipe("カレー");
        Debug.Log("kare-" + kare.name);

    }

    void Cook(CookItem cook_item, Bag player_bag)
    {
        //レシピの情報をひぱってくる
        //CookItem recipe_data = gameData.getRecipe(recipe_name);

        //バッグに素材が入っているかの確認
        foreach(Sozai need_sozai in cook_item.sozai) { 

        }
        
    }
}

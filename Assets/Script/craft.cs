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

        //CookItem kare = gameData.getRecipe("�����Ⴊ");
        //Debug.Log("kare-" + kare.name);
        //Cook(kare, player.getPlayerBag());

    }

    bool canCook(CookItem cook_item, Bag player_bag)
    {
        //���V�s�̏����Ђς��Ă���
        //CookItem recipe_data = gameData.getRecipe(recipe_name);

        //�o�b�O�ɑf�ނ������Ă��邩�̊m�F
        //foreach(Sozai need_sozai in cook_item.sozai) 
        //{
        //    Item item = gameData.getItemFromId(need_sozai.id);
        //    if (player_bag.getSummary()[item] < need_sozai.num)
        //    {
        //        Debug.Log("�����ł��Ȃ�");
        //        return false;
        //    }
        //}

        return true;

    }

   
    void Cook(string recipe_id, Bag player_bag)
    {
        //���V�s�̏����Ђς��Ă���
        CookItem recipe_data = gameData.getRecipe(recipe_id);

        //�o�b�N����f�ނ�����(���m�F��canCook�ōs��)
        foreach (Sozai need_sozai in recipe_data.sozai)
        {
            Item item = gameData.getItem(need_sozai.id);
            player_bag.deleteItem(item.id, need_sozai.num);
        }

        //����͂܂Ƃ߂Ē����ł��Ȃ��̂Œ������cook_item�͈��
        player_bag.inItem(recipe_id, 1);

    }
}

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

        CookItem kare = gameData.getRecipe("�J���[");
        Debug.Log("kare-" + kare.name);

    }

    void Cook(CookItem cook_item, Bag player_bag)
    {
        //���V�s�̏����Ђς��Ă���
        //CookItem recipe_data = gameData.getRecipe(recipe_name);

        //�o�b�O�ɑf�ނ������Ă��邩�̊m�F
        foreach(Sozai need_sozai in cook_item.sozai) { 

        }
        
    }
}

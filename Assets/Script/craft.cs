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

        CookItem kare = gameData.getRecipe("ÉJÉåÅ[");
        Debug.Log("kare-" + kare.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

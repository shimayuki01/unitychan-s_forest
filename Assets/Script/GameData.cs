using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    ItemDataArray itemDataArray;
    CookItem[] cookItemDataArray;
    Dictionary<string, int> recipe2index;

    // Start is called before the first frame update
    void Start()
    {
        itemDataArray = new JsonReaderFromResourcesFolder().GetItemDataArray();

        cookItemDataArray = new JsonReaderFromResourcesFolder().GetRecipe().gameItems;

        recipe2index = new Dictionary<string, int>();


        for (int i=0; i < cookItemDataArray.Length; i++)
        {
            recipe2index.Add(cookItemDataArray[i].name, i);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CookItem getRecipe(string recipe_name)
    {
        if (!recipe2index.ContainsKey(recipe_name)) { Debug.Log(recipe_name + "‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ"); return null; }
        int index = recipe2index[recipe_name];

        return cookItemDataArray[index];
    }
}

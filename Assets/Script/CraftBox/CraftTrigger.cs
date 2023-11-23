using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CraftTrigger : MonoBehaviour
{
    private bool isInCraftArea = false;
    public Texture craftButtonImage;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("��������!");
        isInCraftArea = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("���ꂽ!");
        isInCraftArea = false;
    }
    void OnGUI()
    {
        if (isInCraftArea)
        {
            if (GUI.Button(new Rect(1500, 970, 110, 100),craftButtonImage))
            {
                print("You clicked the button!");
            }
        }
        
    }
}

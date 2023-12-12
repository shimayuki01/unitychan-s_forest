using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CraftTrigger : MonoBehaviour
{
    private bool isInCraftArea = false;
    public Texture craftButtonImage;
    [SerializeField] Button _actionButton;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("当たった!");
            isInCraftArea = true;
            _actionButton.onClick.AddListener(comment);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("離れた!");
            isInCraftArea = false;
            _actionButton.onClick.RemoveListener(comment);
        }
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

    void comment()
    {
        Debug.Log("イベント実行");
    }
}

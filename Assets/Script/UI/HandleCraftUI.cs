using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCraftUI : MonoBehaviour
{
    // Start is called before the first frame update

    //大元のPanelUIを削除してパネル表示を消す
    public void CloseCraftPanel()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        
    }
}

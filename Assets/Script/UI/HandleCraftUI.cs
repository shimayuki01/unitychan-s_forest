using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCraftUI : MonoBehaviour
{
    // Start is called before the first frame update

    //�匳��PanelUI���폜���ăp�l���\��������
    public void CloseCraftPanel()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
        
    }
}

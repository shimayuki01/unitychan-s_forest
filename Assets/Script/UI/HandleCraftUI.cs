using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCraftUI : MonoBehaviour
{
    [SerializeField] RegisterAction registerAction;

    
    public void CloseCraftPanel()
    {
        // �匳��PanelUI���폜���ăp�l���\��������   
        Time.timeScale = 1f;
        Destroy(gameObject);

        // �Q�[���V�[����MenuScene����NormalScene�ɕύX����
        //registerAction.dyanamicGameScene.setCurrentScene(gameScene.NormalScene);

    }
}

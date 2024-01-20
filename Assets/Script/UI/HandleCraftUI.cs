using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCraftUI : MonoBehaviour
{
    [SerializeField] RegisterAction registerAction;

    
    public void CloseCraftPanel()
    {
        // 大元のPanelUIを削除してパネル表示を消す   
        Time.timeScale = 1f;
        Destroy(gameObject);

        // ゲームシーンをMenuSceneからNormalSceneに変更する
        //registerAction.dyanamicGameScene.setCurrentScene(gameScene.NormalScene);

    }
}

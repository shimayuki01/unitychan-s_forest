using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenuPanel : MonoBehaviour, IMenuUI
{

    [SerializeField] RegisterAction _registerAction;

    private GameObject _panelInstance;


    public GameObject InstiatePanel(GameObject panel)
    {
        if (_panelInstance == null)
        {
            //Debug.Log("open panel");
            _panelInstance = Instantiate(panel);

            // TODO:簡潔に書く
            // クラフトパネルの閉じるボタンにClosePanel()の処理を加える。
            // (クラフトパネルに処理を書きたいがregisterActionをパネル側から参照することができない)
            getCloseButton().onClick.AddListener(CloseButtonClicked);

            _registerAction.dyanamicGameScene.setCurrentScene(gameScene.MenueScene);
            Time.timeScale = 0f;
        }
        return _panelInstance;
    }
    public void ClosePanel()
    {
        // 大元のPanelUIを削除してパネル表示を消す   
        Time.timeScale = 1f;
        Destroy(_panelInstance);

        // ゲームシーンをMenuSceneからNormalSceneに変更する
        _registerAction.dyanamicGameScene.setCurrentScene(gameScene.NormalScene);
    }

    // パネルのクローズボタンを押したときの処理
    private void CloseButtonClicked()
    {
        ClosePanel();
    }

    private Button getCloseButton()
    {

        return _panelInstance.transform.Find("CloseButton").gameObject.GetComponent<Button>();

    }
}

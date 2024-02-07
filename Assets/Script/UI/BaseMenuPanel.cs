using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMenuPanel : MonoBehaviour
{

    [SerializeField] RegisterAction _registerAction;

    public GameObject _panelInstance;


    public void InstiatePanel(GameObject panel)
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
    public void CloseButtonClicked()
    {
        ClosePanel();
    }

    private Button getCloseButton()
    {

        return _panelInstance.transform.Find("CloseButton").gameObject.GetComponent<Button>();

    }
}

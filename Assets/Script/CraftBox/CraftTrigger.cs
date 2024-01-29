using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CraftTrigger : MonoBehaviour
{
    private bool isInCraftArea = false;
    public Sprite craftButtonImage;
    [SerializeField] Button _actionButton;
    [SerializeField] RegisterAction registerAction;
    [SerializeField] GameObject _craftPanelPrefab;
    public GameObject _craftPanelInstance;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInCraftArea = true;
            _actionButton.gameObject.SetActive(true);
            _actionButton.image.sprite = craftButtonImage;
            _actionButton.onClick.AddListener(OpenCraftPanel);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInCraftArea = false;
            _actionButton.onClick.RemoveListener(OpenCraftPanel);
        }
    }


    void OpenCraftPanel()
    {
        if ( _craftPanelInstance == null)
        {
            //Debug.Log("open panel");
            _craftPanelInstance = Instantiate(_craftPanelPrefab);

            // TODO:簡潔に書く
            // クラフトパネルの閉じるボタンにClosePanel()の処理を加える。
            // (クラフトパネルに処理を書きたいがregisterActionをパネル側から参照することができない)
            _craftPanelInstance.transform.Find("CloseButton").gameObject.GetComponent<Button>().onClick.AddListener(ClosePanel);
            
            registerAction.dyanamicGameScene.setCurrentScene(gameScene.MenueScene);
            Time.timeScale = 0f;
        }
    }
    void ClosePanel()
    {
        // 大元のPanelUIを削除してパネル表示を消す   
        Time.timeScale = 1f;
        Destroy(_craftPanelInstance);

        // ゲームシーンをMenuSceneからNormalSceneに変更する
        registerAction.dyanamicGameScene.setCurrentScene(gameScene.NormalScene);
    }
}

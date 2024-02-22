using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class ExecuteAction : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Button _actionButton;
    [SerializeField] BaseMenuPanel _baseMenuPanel;
    [SerializeField] GameObject _bagPanel;
    [SerializeField] BagContensRenderer _bagContensRenderer;

    public GameObject _panelInstance;
    private AsyncOperationHandle<Sprite> handle;
    void Start()
    {
        handle = Addressables.LoadAssetAsync<Sprite>("Assets/050image/food_curryruce.png");
    }


    public void Cook(string cookItem_id)
    {
        // TODO:クックできるかの確認
        _player.Cook(cookItem_id);
    }

    public void Walk(Vector2 walkVector)
    {
        // 歩く処理
        _player.Walk(walkVector);
    }

    public void action()
    {
        _actionButton.onClick.Invoke();
    }

    public void closePanel()
    {
        _baseMenuPanel.CloseButtonClicked();
    }


    public void openBag()
    {






        foreach (var i in _player.getBagSummary())
        {
            Debug.Log(i.Key + " " + i.Value);
        }

        Dictionary<string, int> bagSummary = _player.getBagSummary();

        _baseMenuPanel.InstiatePanel(_bagPanel);
        _bagContensRenderer.DisplayItems(_baseMenuPanel._panelInstance, bagSummary);

        // ロード完了を待機する
        GameObject itemPanelParent = _baseMenuPanel._panelInstance.transform.Find("ItemPanel").gameObject;
        int idx = 0;

        GameObject itemPanel = itemPanelParent.transform.GetChild(idx).gameObject;
        Debug.Log(itemPanel.transform.Find("Image").gameObject);
        Image panelText = itemPanel.transform.Find("Image").gameObject.GetComponent<Image>();
        panelText.sprite = Instantiate(handle.Result);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class RegisterAction : MonoBehaviour
{
    [SerializeField] InputKey _inputKey;
    [SerializeField] ExecuteAction _executeAction;

    public DyanamicGameScene dyanamicGameScene;
    Dictionary<string, Dictionary<string, List<KeyCode>>> _state2Keyconfig = new Dictionary<string, Dictionary<string, List<KeyCode>>>();

    private void Start()
    {
        InitKeyconfig();
        dyanamicGameScene = new DyanamicGameScene();

        _inputKey.OnDownWASD.Subscribe(walkVector => { _executeAction.Walk(walkVector);});


        _inputKey.OnKeyDown.Subscribe(pressedKey =>
        {
            // 通常画面のキーコンフィグ
            if (dyanamicGameScene.getCurrentScene() == gameScene.NormalScene)
            {
                Debug.Log("NormalScene pressd " + pressedKey);
                // 接触ボタンのキーが入力された
                if (_state2Keyconfig["Normal"]["Contact"].Contains(pressedKey))
                {
                    _executeAction.action();
                }
                
                if (_state2Keyconfig["Normal"]["OpenBag"].Contains(pressedKey))
                {
                    _executeAction.openBag();
                }

            }

            // メニュー画面のキーコンフィグ
            if (dyanamicGameScene.getCurrentScene() == gameScene.MenueScene)
            {
                Debug.Log("MenuScene pressd " + pressedKey);
                // メニューを閉じるキーが入力された
                if (_state2Keyconfig["Menu"]["ClosePanel"].Contains(pressedKey))
                {
                    _executeAction.closePanel();
                }

            }
        });


    }
                
    

    void InitKeyconfig()
    {
        //_stete2keyconfigに追加するための辞書
        Dictionary<string, List<KeyCode>> _tempAppend = new Dictionary<string, List<KeyCode>>();

        _tempAppend.Add( "Contact", new List<KeyCode>(){ KeyCode.F });
        _tempAppend.Add( "OpenBag", new List<KeyCode>(){ KeyCode.B });
        _state2Keyconfig.Add("Normal", new Dictionary<string, List<KeyCode>>(_tempAppend));

        
        _tempAppend.Clear();
        _tempAppend.Add("ClosePanel", new List<KeyCode>() { KeyCode.Escape });
        _state2Keyconfig.Add("Menu", new Dictionary<string, List<KeyCode>>(_tempAppend));

    }

    void NormalKey()
    {

    }

    
}

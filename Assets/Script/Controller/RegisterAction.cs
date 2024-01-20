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
            if (dyanamicGameScene.getCurrentScene() == gameScene.NormalScene)
            {
                Debug.Log("NormalScene pressd " + pressedKey);
                if (_state2Keyconfig["Normal"]["Contact"].Contains(pressedKey))
                {
                    _executeAction.action();
                }
            }
            if (dyanamicGameScene.getCurrentScene() == gameScene.MenueScene)
            {
                Debug.Log("MenuScene pressd " + pressedKey);
                if (_state2Keyconfig["Menu"]["ClosePanel"].Contains(pressedKey))
                {
                    _executeAction.action();
                }

            }
        });


    }
                
    

    void InitKeyconfig()
    {
        //_stete2keyconfigに追加するための辞書
        Dictionary<string, List<KeyCode>> _tempAppend = new Dictionary<string, List<KeyCode>>();

        _tempAppend.Add( "Contact", new List<KeyCode>(){ KeyCode.F });
        _state2Keyconfig.Add("Normal", new Dictionary<string, List<KeyCode>>(_tempAppend));

        _tempAppend.Clear();
        _tempAppend.Add("ClosePanel", new List<KeyCode>() { KeyCode.Escape });
        _state2Keyconfig.Add("Menu", new Dictionary<string, List<KeyCode>>(_tempAppend));

    }

    void NormalKey()
    {

    }

    
}

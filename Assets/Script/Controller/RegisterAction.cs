using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class RegisterAction : MonoBehaviour
{
    [SerializeField] InputKey _inputKey;
    [SerializeField] ExecuteAction _executeAction;

    Dictionary<string, List<KeyCode>> _action2key = new Dictionary<string, List<KeyCode>>();

    private void Start()
    {
        InitKeyconfig();

        _inputKey.OnDownWASD.Subscribe(value => { _executeAction.Walk(value);});


        _inputKey.OnKeyDown.Subscribe(value => {
            if (_action2key["actionA"].Contains(value)){
                _executeAction.action();
            } });
    }

    void InitKeyconfig()
    {

        _action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class RegisterAction : MonoBehaviour
{
    [SerializeField] InputKey _inputKey;
    [SerializeField] ExecuteAction _executeAction;

    Dictionary<string, List<KeyCode>> _action2key = new Dictionary<string, List<KeyCode>>();
    public DyanamicGameCondition dyanamicGameCondition;

    private void Start()
    {
        InitKeyconfig();
        dyanamicGameCondition = new DyanamicGameCondition();

        _inputKey.OnDownWASD.Subscribe(value => { _executeAction.Walk(value);});


        _inputKey.OnKeyDown.Subscribe(value =>
        {
            if (dyanamicGameCondition.getCurrentScene() == DyanamicGameCondition.gameCondition.NormalScene)
            {
                Debug.Log("ノーマルシーンで入力が行われています" + value);
                if (_action2key["action"].Contains(value))
                {
                    _executeAction.action();
                }
            }
            if (dyanamicGameCondition.getCurrentScene() == DyanamicGameCondition.gameCondition.MenueScene)
            {   
                Debug.Log("メニューシーンで入力が行われています。："+ value);
                
            }
        });
    }
                
    

    void InitKeyconfig()
    {

        _action2key.Add( "action", new List<KeyCode>(){ KeyCode.F });
        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
    }
    
}

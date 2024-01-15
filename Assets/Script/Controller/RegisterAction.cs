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
    Dictionary<string, List<KeyCode>> _tempAppend = new Dictionary<string, List<KeyCode>>();//_stete2keyconfig
    Dictionary<string, Dictionary<string, List<KeyCode>>> _state2Keyconfig = new Dictionary<string, Dictionary<string, List<KeyCode>>>();

    private void Start()
    {
        InitKeyconfig();
        dyanamicGameCondition = new DyanamicGameCondition();

        _inputKey.OnDownWASD.Subscribe(value => { _executeAction.Walk(value);});


        // _inputKey.OnKeyDown.Subscribe(value =>
        // {
        //     if (dyanamicGameCondition.getCurrentScene() == DyanamicGameCondition.gameCondition.NormalScene)
        //     {
        //         Debug.Log("�m�[�}���V�[���œ��͂��s���Ă��܂�" + value);
        //         if (_action2key["action"].Contains(value))
        //         {
        //             _executeAction.action();
        //         }
        //     }
        //     if (dyanamicGameCondition.getCurrentScene() == DyanamicGameCondition.gameCondition.MenueScene)
        //     {   
        //         Debug.Log("���j���[�V�[���œ��͂��s���Ă��܂��B�F"+ value);
                
        //     }
        // });
        _inputKey.OnKeyDown.Subscribe(value => {
            _tempAppend.Clear();
            Debug.Log(_tempAppend["Contact"]);
            _tempAppend = _state2Keyconfig["Normal"];

            if (_tempAppend["Contact"].Contains(value)){
                _executeAction.action();
            }
            else if (/*_state2Keyconfig["Menu"]["ClosePanel"].Contains(value)*/ false)
            {
                Debug.Log("�G�X�P�[�v");            }
        });

    }
                
    

    void InitKeyconfig()
    {
        _tempAppend.Clear();
        //todo �R�s�[���������Ŏ�����n��(�N���A������n�����̂�������)
        _tempAppend.Add( "Contact", new List<KeyCode>(){ KeyCode.F });
        Debug.Log(_tempAppend["Contact"]);
        _state2Keyconfig.Add("Normal",_tempAppend);
        Debug.Log(_state2Keyconfig["Normal"]);

        _tempAppend.Clear();
        _tempAppend.Add("ClosePanel", new List<KeyCode>() { KeyCode.Escape });
        _state2Keyconfig.Add("Menu", _tempAppend);

        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
        //_action2key.Add( "actionA", new List<KeyCode>(){ KeyCode.F });
    }

    void NormalKey()
    {

    }

    
}

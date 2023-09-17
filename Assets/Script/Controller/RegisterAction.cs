using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class RegisterAction : MonoBehaviour
{
    [SerializeField] InputKey _inputKey;
    [SerializeField] ExecuteAction _executeAction;
    private void Start()
    {
        _inputKey.OnDownWASD.Subscribe(value => _executeAction.Walk(value));
    }
    
}

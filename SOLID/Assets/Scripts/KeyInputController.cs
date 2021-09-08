using System.Collections.Generic;
using UnityEngine;

public class KeyInputController : Singleton<KeyInputController>
{
    private Dictionary<KeyCode, ResponseContainer> keyDictionary = new Dictionary<KeyCode, ResponseContainer>();

    private void OnEnable()
    {
        Instance = this;
    }

    private void Update()
    {
        foreach(var kv in keyDictionary)
        {
            if (Input.GetKeyDown(kv.Key))
            {
                kv.Value.OnKeyDown?.Invoke();
            }

            if (Input.GetKeyUp(kv.Key))
            {
                kv.Value.OnKeyUp?.Invoke();
            }

            if (Input.GetKey(kv.Key))
            {
                kv.Value.OnKeyPressed?.Invoke();
            }
        }
    }

    public void RegisterKey(
        KeyCode _key,
        System.Action _downResponse = null,
        System.Action _pressedResponse = null, 
        System.Action _upResponse = null
        )
    {
        Debug.Log("Registerd a key: " + _key);
        if (!keyDictionary.ContainsKey(_key))
        {
            keyDictionary.Add(_key, new ResponseContainer());
        }

        ResponseContainer keyContainer = keyDictionary[_key];
        if (_downResponse != null)
        {
            keyContainer.OnKeyDown += _downResponse;
        }
        if (_pressedResponse != null)
        {
            keyContainer.OnKeyPressed += _pressedResponse;
        }

        if (_upResponse != null)
        {
            keyContainer.OnKeyUp += _upResponse;
        }

    }

    public void UnRegisterKey(
        KeyCode _key,
        System.Action _downResponse = null,
        System.Action _pressedResponse = null,
        System.Action _upResponse = null
        )
    {
        if (!keyDictionary.ContainsKey(_key)) { return; }
        ResponseContainer container = keyDictionary[_key];
        if(_pressedResponse != null)
        {
            container.OnKeyPressed -= _pressedResponse;
        }
        if (_upResponse != null)
        {
            container.OnKeyUp -= _upResponse;
        }
        if (_downResponse != null)
        {
            container.OnKeyDown -= _downResponse;
        }
    }
}
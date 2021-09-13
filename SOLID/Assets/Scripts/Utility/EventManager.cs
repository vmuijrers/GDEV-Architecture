using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EventType
{
    ON_PLAYER_HIT   = 0,
    ON_PLAYER_DEAD  = 1,
    ON_PLAYER_JUMP  = 2,
    ON_PLAYER_SHOOT = 3
}

public static class EventManager
{
    private static Dictionary<EventType, System.Action> eventDictionary = new Dictionary<EventType, System.Action>();

    public static void Register(EventType _eventType, System.Action _listener)
    {
        if (!eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary.Add(_eventType, null);
        }
        eventDictionary[_eventType] += _listener;
    }

    public static void UnRegister(EventType _eventType, System.Action _listener)
    {
        if (eventDictionary.ContainsKey(_eventType))
        {
            System.Action result = eventDictionary[_eventType];
            if (result != null)
            {
                result -= _listener;
            } else
            {
                Debug.LogWarning("Somehting went wrong with event: " + _eventType);
            }
        }
    }

    public static void Invoke(EventType _eventType)
    {
        if (eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary[_eventType]?.Invoke();
        }
    }


}

public static class EventManager<T>
{
    private static Dictionary<EventType, System.Action<T>> eventDictionary = new Dictionary<EventType, System.Action<T>>();

    public static void Register(EventType _eventType, System.Action<T> _listener)
    {
        if (!eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary.Add(_eventType, null);
        }
        eventDictionary[_eventType] += _listener;
    }

    public static void UnRegister(EventType _eventType, System.Action<T> _listener)
    {
        if (eventDictionary.ContainsKey(_eventType))
        {
            System.Action<T> result = eventDictionary[_eventType];
            if (result != null)
            {
                result -= _listener;
            } else
            {
                Debug.LogWarning("Somehting went wrong with event: " + _eventType);
            }
        }
    }

    public static void Invoke(EventType _eventType, T _arg1)
    {
        if (eventDictionary.ContainsKey(_eventType))
        {
            eventDictionary[_eventType]?.Invoke(_arg1);
        }
    }
}


//EventManager.Register(EventType.ON_PLAYER_HIT, DoSomethingCool);
//EventManager.UnRegister(EventType.ON_PLAYER_HIT, DoSomethingCool);
//EventManager.Invoke(EventType.ON_PLAYER_HIT);
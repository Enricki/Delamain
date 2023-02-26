using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener: MonoBehaviour
{


    private void Awake()
    {

    }


}

public class EventListener
{
    private GameEvent _gameEvent;
    private UnityEvent _unityEvent;

    public EventListener(GameEvent gameEvent)
    {
        _gameEvent = gameEvent;
        _unityEvent = new UnityEvent();
    }

    public void AddAction(UnityAction action)
    {
        _unityEvent.AddListener(action);
    }

    public void EventRaised()
    {
        _unityEvent?.Invoke();
    }

    public void Subscribe()
    {
        _gameEvent.AddListener(this);
    }

    public void UnSubscribe()
    {
        _gameEvent.RemoveListener(this);
    }
}
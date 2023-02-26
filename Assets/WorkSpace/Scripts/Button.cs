using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameEvent _gameEvent;

    EventSender _sender;

    public void Interact()
    {
        _sender.SendEvent();
    }

    private void Start()
    {
        _sender = new EventSender(_gameEvent);
    }
}

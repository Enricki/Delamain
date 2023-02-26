using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameEvent _gameEvent;


    EventListener _eventListener;


    // Start is called before the first frame update
    void Awake()
    {
        _eventListener = new EventListener(_gameEvent);
        _eventListener.AddAction(OpenDoor);
    }

    public void OpenDoor()
    {
        transform.localPosition = transform.localPosition + Vector3.forward * 3;
    }

    private void OnEnable()
    {
        _eventListener.Subscribe();
    }

    private void OnDisable()
    {
        _eventListener.UnSubscribe();
    }
}

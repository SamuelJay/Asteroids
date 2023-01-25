using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    private EventManager eventManager
    {
        get 
            {
            return manager.eventManager;
            }
    }
    public Manager manager { get; private set; }
    public virtual void Setup(Manager manager)
    {
        this.manager = manager;
    }

    public void StartListeningToEvent<T>(EventHandler callback)
    {
        eventManager.StartListening<T>(callback);
    }

    public void StopListeningToEvent<T>(EventHandler callback)
    {
        eventManager.StopListening<T>(callback);
    }

    public void TriggerEvent<T>(BaseEvent eventArgs)
    {
        eventManager.Trigger<T>(eventArgs);
    }
}

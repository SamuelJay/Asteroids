using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected StateMachineBehaviour stateMachineBehaviour;

    public State (StateMachineBehaviour stateMachineBehaviour)
    {
        this.stateMachineBehaviour = stateMachineBehaviour;
    }

    public virtual void UpdateState()
    {
        Debug.Log("State UpdateState");
    }

    public virtual void EnterState()
    {
        Debug.Log("State EnterState");
      
    }
    protected virtual void EndState(State nextState) 
    {
        Debug.Log("State EndState");
        stateMachineBehaviour.SetState(nextState);
    }
    public void StartListeningToEvent<T>(EventHandler callback)
    {
        stateMachineBehaviour.StartListeningToEvent<T>(callback);
    }

    public void StopListeningToEvent<T>(EventHandler callback)
    {
        stateMachineBehaviour.StopListeningToEvent<T>(callback);
    }

    public void TriggerEvent<T>(BaseEvent eventArgs)
    {
        stateMachineBehaviour.TriggerEvent<T>(eventArgs);
    }
}

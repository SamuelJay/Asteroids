using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : State
{

    public WeaponIdleState(StateMachineBehaviour stateMachineBehaviour) :base(stateMachineBehaviour) 
    {
        Debug.Log("WeaponIdleState");
        StartListeningToEvent<ShootPressedEvent>(OnShootPressed);
    }

    

    private void OnShootPressed(object sender, EventArgs e)
    {
        Debug.Log("WeaponIdleState OnShootPressed");
        EndState(new WeaponShootingState(stateMachineBehaviour));
    }
    protected override void EndState(State nextState)
    {
        StopListeningToEvent<ShootPressedEvent>(OnShootPressed);
        Debug.Log("WeaponIdleState EndState");
        base.EndState(nextState);

    }

}

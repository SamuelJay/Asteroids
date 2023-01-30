using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : State
{
    private WeaponData data;
    public WeaponIdleState(StateMachineBehaviour stateMachineBehaviour, WeaponData data) : base(stateMachineBehaviour) 
    {
        Debug.Log("WeaponIdleState");
        this.data = data;
        StartListeningToEvent<ShootPressedEvent>(OnShootPressed);
    }

    private void OnShootPressed(object sender, EventArgs e)
    {
        Debug.Log("WeaponIdleState OnShootPressed");
        EndState(new WeaponShootingState(stateMachineBehaviour, data));
    }
    protected override void EndState(State nextState)
    {
        StopListeningToEvent<ShootPressedEvent>(OnShootPressed);
        Debug.Log("WeaponIdleState EndState");
        base.EndState(nextState);
    }
}

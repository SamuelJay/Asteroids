using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : State
{

    public WeaponIdleState(StateMachineBehaviour stateMachineBehaviour) :base(stateMachineBehaviour) 
    {
        StartListeningToEvent<ShootPressedEvent>(OnShootPressed);
    }

    

    private void OnShootPressed(object sender, EventArgs e)
    {
        EndState(new WeaponShootingState(stateMachineBehaviour));
    }
}

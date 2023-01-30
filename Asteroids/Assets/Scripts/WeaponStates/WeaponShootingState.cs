using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootingState : State
{
    WeaponBehaviour weaponBehaviour=> stateMachineBehaviour as WeaponBehaviour;
    public WeaponShootingState(StateMachineBehaviour stateMachineBehaviour) : base(stateMachineBehaviour) 
    {
        Debug.Log("WeaponShootingState");
        
    }
    public override void EnterState()
    {
        base.EnterState();
        Shoot();
    }
    private void Shoot() 
    {
        weaponBehaviour.Shoot();
        EndState(new WeaponCoolDownState(stateMachineBehaviour));

    }
    protected override void EndState(State nextState)
    {
        Debug.Log("WeaponShootingState EndState");
        base.EndState(nextState);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootingState : State
{
    WeaponData data;
    WeaponBehaviour weaponBehaviour=> stateMachineBehaviour as WeaponBehaviour;
    public WeaponShootingState(StateMachineBehaviour stateMachineBehaviour, WeaponData data) : base(stateMachineBehaviour) 
    {
        Debug.Log("WeaponShootingState");
        this.data = data;
    }
    public override void EnterState()
    {
        base.EnterState();
        Shoot();
    }
    private void Shoot() 
    {
        weaponBehaviour.Shoot();
        EndState(new WeaponCoolDownState(stateMachineBehaviour, data));

    }
    protected override void EndState(State nextState)
    {
        Debug.Log("WeaponShootingState EndState");
        base.EndState(nextState);

    }

}

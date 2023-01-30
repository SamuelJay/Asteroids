using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCoolDownState : State
{
    private WeaponBehaviour weaponBehaviour => stateMachineBehaviour as WeaponBehaviour;
    WeaponData data => weaponBehaviour.data;
    private float waitTime;
    private float timer;
    private bool burst;
    public WeaponCoolDownState(StateMachineBehaviour stateMachineBehaviour) : base(stateMachineBehaviour)
    {
        Debug.Log("WeaponCoolDownState");
        timer = 0;
        burst = weaponBehaviour.burstCount > 0;
        waitTime = (burst) ? data.GetFireRate() : data.GetCoolDownTime();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("WeaponCoolDownState UpdateState");
        timer += Time.deltaTime;
        
        if (timer >= waitTime)
        {
            if (burst) 
            {
                EndState(new WeaponShootingState(weaponBehaviour));
            }
            else
            {
                weaponBehaviour.EndBurst();
                EndState(new WeaponIdleState(weaponBehaviour));
            }
        }
    }
}

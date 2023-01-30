using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCoolDownState : State
{
    private WeaponBehaviour weaponBehaviour => stateMachineBehaviour as WeaponBehaviour;
    WeaponData data;
    private float waitTime;
    private float timer;
    private bool burst;
    public WeaponCoolDownState(StateMachineBehaviour stateMachineBehaviour, WeaponData data) : base(stateMachineBehaviour)
    {
        //Debug.Log("WeaponCoolDownState");
        this.data = data;
        timer = 0;
        burst = weaponBehaviour.burstCount > 0;
        waitTime = (burst) ? data.GetFireRate() : data.GetCoolDownTime();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //Debug.Log("WeaponCoolDownState UpdateState");
        timer += Time.deltaTime;
        
        if (timer >= waitTime)
        {
            if (burst) 
            {
                EndState(new WeaponShootingState(weaponBehaviour, data));
            }
            else
            {
                weaponBehaviour.EndBurst();
                EndState(new WeaponIdleState(weaponBehaviour,data));
            }
        }
    }
}

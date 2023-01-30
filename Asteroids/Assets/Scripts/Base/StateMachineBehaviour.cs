using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour : BaseBehaviour
{
    protected State state;

    public void SetState(State state) 
    {
        //Debug.Log($"StateMachineBehaviour SetState WeaponIdleState:{state as WeaponIdleState != null} WeaponShootingState:{state as WeaponShootingState != null} WeaponCoolDownState:{state as WeaponCoolDownState != null}");
        this.state = state;
        state.EnterState();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : StateMachineBehaviour
{
    public WeaponData data { get; private set; }

    public void Setup(Manager manager, WeaponData data)
    {
        base.Setup(manager);
        this.data = data;
        SetState(new WeaponIdleState(this));
    }

    
}

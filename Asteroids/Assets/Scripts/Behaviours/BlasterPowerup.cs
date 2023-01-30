using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterPowerup : BasePowerup
{
    BlasterPowerupData blasterPowerupData => powerupData as BlasterPowerupData;
    protected override void Use(PlayerBehaviour playerBehaviour)
    {
        base.Use(playerBehaviour);
        playerBehaviour.ChangeToSecondaryWeapon();
        playerBehaviour.StartWaitThenWeaponChangeBack(blasterPowerupData.GetEffectDuration());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPowerup : BasePowerup
{
    BarrierPowerupData barrierPowerupData=> powerupData as BarrierPowerupData;
    public override void Setup(Manager manager, PowerupData powerupData)
    {
        base.Setup(manager, powerupData);
    }
    protected override void Use(PlayerBehaviour playerBehaviour)
    {
        base.Use(playerBehaviour);
        playerBehaviour.TurnOnBarrier(barrierPowerupData.GetNumberOfHits());
    }
}

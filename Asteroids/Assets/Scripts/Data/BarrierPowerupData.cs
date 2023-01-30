using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BarrierPowerupData", fileName = "New Barrier Powerup Data")]
public class BarrierPowerupData : PowerupData
{
    [SerializeField] private int numberOfHits;

    public int GetNumberOfHits() 
    { 
        return numberOfHits; 
    }
}

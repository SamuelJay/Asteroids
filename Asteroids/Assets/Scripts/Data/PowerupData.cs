using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerupData", fileName = "New Powerup Data")]
public class PowerupData : ScriptableObject
{
    [SerializeField] protected int effectDuration;
    [SerializeField] protected Sprite sprite; 

}

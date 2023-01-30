using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WeaponData", fileName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] bool fullAuto;
    [SerializeField] int burstAmount;
    [SerializeField] float fireRate;
    [SerializeField] float coolDownTime;
    [SerializeField] int damage;
}

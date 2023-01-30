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
    [SerializeField] int bulletSpeed;
    [SerializeField] int damage;

    public bool GetFullAuto()
    {
        return fullAuto;
    }
    
    public int GetBurstAmount()
    {
        return burstAmount;
    } 
    
    public float GetFireRate()
    {
        return fireRate;
    }
    
    public float GetCoolDownTime()
    {
        return fireRate;
    }

    public int GetBulletSpeed ()
    {
        return bulletSpeed;
    }
    
    public int GetDamage()
    {
        return damage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WeaponData", fileName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] bool fullAuto;
    [SerializeField] int burstAmount;
    [SerializeField] float fireRate;
    [SerializeField] float coolDownTime;
    [SerializeField] int bulletSpeed;
    [SerializeField] float bulletLifeTime;
    [SerializeField] int damage;

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }

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

    public int GetBulletSpeed()
    {
        return bulletSpeed;
    }
    
    public float GetBulletLifeTime()
    {
        return bulletLifeTime;
    }
    
    public int GetDamage()
    {
        return damage;
    }
}

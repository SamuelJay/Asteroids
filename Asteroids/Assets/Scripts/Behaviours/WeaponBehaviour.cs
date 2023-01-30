using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : StateMachineBehaviour
{
    [SerializeField] private GameObject weaponPrefab;
    public WeaponData data { get; private set; }
    private ObjectPooler bulletPool;
    public int burstCount;
    public void Setup(Manager manager, WeaponData data)
    {
        base.Setup(manager);
        this.data = data;
        bulletPool = new ObjectPooler(20, weaponPrefab);
        SetState(new WeaponIdleState(this));
        burstCount = data.GetBurstAmount();
    }

    private void Update()
    {
        state.UpdateState();
    }

    public void Shoot()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);
        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.Setup(manager, data.GetBulletSpeed(), data.GetBulletLifeTime());
        burstCount--;
    }

    public void EndBurst()
    {
        burstCount = data.GetBurstAmount();
    }
}

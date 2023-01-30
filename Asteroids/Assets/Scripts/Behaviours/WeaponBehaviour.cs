using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : StateMachineBehaviour
{
    [SerializeField] private WeaponData data;
    private GameObject bulletPrefab;
    private ObjectPooler bulletPool;
    public int burstCount { get; private set; }

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        bulletPrefab = data.GetBulletPrefab();
        bulletPool = new ObjectPooler(bulletPrefab);
        bulletPool.CreatePool();
        SetState(new WeaponIdleState(this, data));
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
    private void OnDisable()
    {
        SetState(new WeaponIdleState(this, data));
    }
    public void EndBurst()
    {
        burstCount = data.GetBurstAmount();
    }
    private void OnDestroy()
    {
       
    }
}

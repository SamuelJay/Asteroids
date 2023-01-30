using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : BaseBehaviour
{
    [SerializeField] protected PowerupData powerupData;

    public virtual void Setup(Manager manager, PowerupData powerupData)
    {
        base.Setup(manager);
    }
    protected void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour playerBehaviour = other.GetComponent<PlayerBehaviour>();
        if (playerBehaviour != null)
        {
            Debug.Log($"PowerupTrigger {other.gameObject.name}");
            Use(playerBehaviour);
            Destroy(gameObject);
        }
    }

    protected virtual void Use(PlayerBehaviour playerBehaviour)
    { }
   
    
}


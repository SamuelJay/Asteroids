using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : BaseBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"PowerupTrigger {other.gameObject.name}");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"PowerupCollision {collision.gameObject.name}");
        Destroy(gameObject);
    }
    
}


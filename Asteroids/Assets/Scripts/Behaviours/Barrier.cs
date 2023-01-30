using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BaseBehaviour
{
    private int hitCount;
    private int numberOfHits;
    private PlayerBehaviour playerBehaviour;

    public void Setup(Manager manager, PlayerBehaviour playerBehaviour,
        int numberOfHits)
    {
        base.Setup(manager);
        this.playerBehaviour = playerBehaviour;
        this.numberOfHits = numberOfHits;
        hitCount = 0;
    }
    private void Update()
    {
        transform.position = playerBehaviour.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        AsteroidBehaviour asteroidBehaviour = collision.gameObject.GetComponent<AsteroidBehaviour>();
        if (asteroidBehaviour != null)
        {
            Debug.Log("Barrier Collsion");
            hitCount++;
            if (hitCount >= numberOfHits)
            {
                Destroy(gameObject);
            }
        }
    }

   

   /* private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Barrier Trigger");
        hitCount++;
        if (hitCount >= numberOfHits)
        {
            gameObject.SetActive(false);
        }
    }*/
}

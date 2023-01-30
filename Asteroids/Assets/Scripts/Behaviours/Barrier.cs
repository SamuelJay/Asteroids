using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BaseBehaviour
{
    private int hitCount;
    private int numberOfHits;
    public void Setup(Manager manager,
        int numberOfHits)
    {
        base.Setup(manager);
        this.numberOfHits = numberOfHits;
        hitCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Barrier Collsion");
        hitCount++;
        if (hitCount >= numberOfHits)
        { 
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Barrier Trigger");
        hitCount++;
        if (hitCount >= numberOfHits)
        {
            gameObject.SetActive(false);
        }
    }
}

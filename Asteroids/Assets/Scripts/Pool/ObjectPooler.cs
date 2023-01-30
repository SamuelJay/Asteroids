using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler 
{
    private GameObject poolObjectPrefab;
    private List<GameObject> pooledObjects;

    public ObjectPooler (GameObject objectPrefab)
    {
        this.poolObjectPrefab = objectPrefab;
        
    }

    public void CreatePool() 
    {
        pooledObjects = new List<GameObject>();
    
    }

    public GameObject GetPooledObject()
    {
        // Check if there is an inactive object in the pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // If all objects are active, create a new one
        GameObject newObject = Object.Instantiate(poolObjectPrefab);
        newObject.SetActive(false);
        pooledObjects.Add(newObject);
        return newObject;
    }
}

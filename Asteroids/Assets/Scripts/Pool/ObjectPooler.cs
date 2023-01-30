using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler 
{
    private int poolSize;
    private GameObject objectPrefab;
    private List<GameObject> pooledObjects;

    public ObjectPooler (int poolSize, GameObject objectPrefab)
    {
        this.poolSize = poolSize;
        this.objectPrefab = objectPrefab;
        CreatePool();
    }

    private void CreatePool() 
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
        GameObject obj = Object.Instantiate(objectPrefab);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}

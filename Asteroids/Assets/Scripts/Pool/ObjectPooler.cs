using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler 
{
    private GameObject poolObjectPrefab;
    private GameObject parent;
    private List<GameObject> pooledObjects;

    public ObjectPooler (GameObject poolObjectPrefab, GameObject parent)
    {
        this.poolObjectPrefab = poolObjectPrefab;
        this.parent = parent;
    }

    public void CreatePool() 
    {
        pooledObjects = new List<GameObject>();
    
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject newObject = Object.Instantiate(poolObjectPrefab);
        newObject.transform.parent = parent.transform;
        newObject.SetActive(false);
        pooledObjects.Add(newObject);
        return newObject;
    }
}

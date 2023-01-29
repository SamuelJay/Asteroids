using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Controller
{
    
    [SerializeField] private GameObject[] asteroidPrefabs;

    private Dictionary<int, ObjectPooler> asteroidPoolsByStage;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        asteroidPoolsByStage = new Dictionary<int, ObjectPooler>();
        for (int i = 0; i < asteroidPrefabs.Length; i++) 
        {
            asteroidPoolsByStage.Add(i, new ObjectPooler(50, asteroidPrefabs[i]));
        }
    }

    public void CreateNewAsteroids(int amount) 
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject asteroid = asteroidPoolsByStage[0].GetPooledObject();
            asteroid.SetActive(true);
            float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            float halfHeight = Camera.main.orthographicSize;

            Vector3 newPosition = new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), 0);
            //Vector3 newPosition = Camera.main.ScreenToWorldPoint(screenPositon);
            asteroid.transform.position = newPosition; 
        }
    }
}

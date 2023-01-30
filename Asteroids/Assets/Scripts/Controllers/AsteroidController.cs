using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : Controller
{

    [SerializeField] private GameObject[] asteroidPrefabs;
    private AsteroidsData asteroidsData;
    private Dictionary<int, ObjectPooler> asteroidPoolsByStage;

    public void Setup(Manager manager, AsteroidsData asteroidsData)
    {
        base.Setup(manager);
        StartListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
        this.asteroidsData = asteroidsData;
        asteroidPoolsByStage = new Dictionary<int, ObjectPooler>();
        for (int i = 0; i < asteroidPrefabs.Length; i++)
        {
            asteroidPoolsByStage.Add(i, new ObjectPooler(asteroidPrefabs[i]));
        }
    }

    public void CreateNewAsteroids(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject asteroid = asteroidPoolsByStage[0].GetPooledObject();
            AsteroidBehaviour asteroidBehaviour = asteroid.GetComponent<AsteroidBehaviour>();
            asteroid.SetActive(true);
            asteroidBehaviour.Setup(manager, asteroidsData.GetHealth(), asteroidsData.GetSpeed(), 0);
            float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            float halfHeight = Camera.main.orthographicSize;

            Vector3 newPosition = new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), 0);
            //Vector3 newPosition = Camera.main.ScreenToWorldPoint(screenPositon);
            asteroid.transform.position = newPosition;
        }
    }
    private void OnAsteroidDestroyedEvent(object sender, EventArgs e)
    {
        AsteroidDestroyedEvent asteroidDestroyedEvent = (AsteroidDestroyedEvent)e;
        AsteroidBehaviour asteroidBehaviour = asteroidDestroyedEvent.hitAsteroid;
        if (asteroidBehaviour.stage < asteroidsData.GetNumberOfStages())
        {
            int nextStage = asteroidBehaviour.stage + 1;
            GameObject asteroidFragment1 = asteroidPoolsByStage[nextStage].GetPooledObject();
            GameObject asteroidFragment2 = asteroidPoolsByStage[nextStage].GetPooledObject();
            asteroidFragment1.SetActive(true);
            asteroidFragment2.SetActive(true);
            AsteroidBehaviour newAsteroidBehaviour1 = asteroidFragment1.GetComponent<AsteroidBehaviour>();
            AsteroidBehaviour newAsteroidBehaviour2 = asteroidFragment2.GetComponent<AsteroidBehaviour>();
            newAsteroidBehaviour1.transform.position = asteroidBehaviour.transform.position;
            newAsteroidBehaviour2.transform.position = asteroidBehaviour.transform.position;
            newAsteroidBehaviour1.Setup(manager, asteroidsData.GetHealth(), asteroidsData.GetSpeed(), nextStage);
            newAsteroidBehaviour2.Setup(manager, asteroidsData.GetHealth(), asteroidsData.GetSpeed(), nextStage);
        }
        asteroidBehaviour.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
    }
}

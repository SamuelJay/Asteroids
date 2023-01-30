using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : Controller
{
    public float numberOfAsteroidsAfterSplits { get; private set; }
    [SerializeField] private GameObject[] asteroidPrefabs;
    private AsteroidsData asteroidsData;
    private Dictionary<int, ObjectPooler> asteroidPoolsByStage;

    public void Setup(Manager manager, AsteroidsData asteroidsData)
    {
        base.Setup(manager);
        StartListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
        this.asteroidsData = asteroidsData;
        asteroidPoolsByStage = new Dictionary<int, ObjectPooler>();
        GameObject asteroidParent = new GameObject("Asteroids");
        for (int i = 0; i < asteroidPrefabs.Length; i++)
        {

            asteroidPoolsByStage.Add(i, new ObjectPooler(asteroidPrefabs[i], asteroidParent));
            asteroidPoolsByStage[i].CreatePool();
        }
    }

    public void CreateNewAsteroids(int amount)
    {
        int stage = 0;
        for (int i = 0; i < amount; i++)
        {
            GameObject asteroid = asteroidPoolsByStage[0].GetPooledObject();
            AsteroidBehaviour asteroidBehaviour = asteroid.GetComponent<AsteroidBehaviour>();
            asteroid.SetActive(true);
            asteroidBehaviour.Setup(manager, asteroidsData.GetHealth(), asteroidsData.GetSpeed(), stage);
            float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
            float halfHeight = Camera.main.orthographicSize;
            Vector3 newPosition = new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), stage);
            //Vector3 newPosition = Camera.main.ScreenToWorldPoint(screenPositon);
            asteroid.transform.position = newPosition;
        }
        numberOfAsteroidsAfterSplits = amount * Mathf.Pow(asteroidsData.GetNumberOfFragments(), asteroidsData.GetNumberOfStages());
        Debug.Log($"AsteroidController CreateNewAsteroids {numberOfAsteroidsAfterSplits}");
    }
    private void OnAsteroidDestroyedEvent(object sender, EventArgs e)
    {
        AsteroidDestroyedEvent asteroidDestroyedEvent = (AsteroidDestroyedEvent)e;
        AsteroidBehaviour asteroidBehaviour = asteroidDestroyedEvent.hitAsteroid;
        Debug.Log($"AsteroidCOntroller OnAsteroidDestroyedEvent {asteroidBehaviour.stage}");
        Vector3 position = asteroidBehaviour.transform.position;
        asteroidBehaviour.gameObject.SetActive(false);
         if (asteroidBehaviour.stage < asteroidsData.GetNumberOfStages())
        {
            int nextStage = asteroidBehaviour.stage + 1;
           
            for (int i = 0; i < asteroidsData.GetNumberOfFragments(); i++)
            {
                GameObject asteroidFragment = asteroidPoolsByStage[nextStage].GetPooledObject();
                asteroidFragment.SetActive(true);
                AsteroidBehaviour newAsteroidBehaviour = asteroidFragment.GetComponent<AsteroidBehaviour>();
                newAsteroidBehaviour.transform.position = position;
                newAsteroidBehaviour.Setup(manager, asteroidsData.GetHealth(), asteroidsData.GetSpeed(), nextStage);
            }
        }
    }

    private void OnDestroy()
    {
        StopListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
    }
}

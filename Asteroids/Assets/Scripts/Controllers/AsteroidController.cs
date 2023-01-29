using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Controller
{
    [SerializeField] private AsteroidsData asteroidsData;
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
}

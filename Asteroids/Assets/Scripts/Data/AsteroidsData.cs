using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AsteroidsData", fileName = "New Asteroids Data")]
public class AsteroidsData : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int numberOfStages;
    [SerializeField] private int speed;

    public int GetHealth()
    {
        return health;
    }

    public int GetNumberOfStages()
    {
        return numberOfStages;
    }

    public int GetSpeed()
    {
        return speed;
    }
}
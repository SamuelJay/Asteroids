using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData", fileName = "New Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private int powerupFrequency;
    [SerializeField] private int pointsForDestroyingAsteroids;

    public int GetPowerupFrequency() 
    {
        return powerupFrequency;
    }
    
    public int GetPointsForDestroyingAsteroids() 
    {
        return pointsForDestroyingAsteroids;
    }
}

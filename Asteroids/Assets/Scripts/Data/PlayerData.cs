using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData", fileName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;

    public int GetHealth() 
    {
        return health;
    }
    public int GetSpeed()
    {
        return speed;
    }

    public int GetRotationSpeed()
    {
        return rotationSpeed;
    }
}

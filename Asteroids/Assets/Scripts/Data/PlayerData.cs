using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData", fileName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;

    public int Health() 
    {
        return health;
    }
    public int Speed()
    {
        return speed;
    }

    public int RotationSpeed()
    {
        return rotationSpeed;
    }
}

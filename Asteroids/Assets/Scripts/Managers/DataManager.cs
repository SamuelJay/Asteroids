using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Manager
{
    [SerializeField] private PlayerData[] playerData;

    public PlayerData GetPlayerDataForLevel(int level) => playerData[level];
}

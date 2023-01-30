using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : Manager
{
    public int score { get; private set; }
    public InputActions inputActions { get; private set; }
    
    [SerializeField] private AsteroidsData asteroidsData;
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject asteroidControllerPrefab;
    [SerializeField] private GameObject[] powerupPrefabs;

    private int asteroidsDestroyedCount;
    private GameObject playerObject;
    private GameObject asteroidControllerObject;
    private PlayerBehaviour playerBehaviour; 
    private AsteroidController asteroidController;
    private AppManager appManager => manager as AppManager;
    private DataManager dataManager=> appManager.dataManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);

        StartListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
        StartListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);

        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.AppControls.Menu.performed += OnMenuPressed;

        playerObject = Instantiate(playerPrefab);
        playerBehaviour = playerObject.GetComponent<PlayerBehaviour>();
        playerBehaviour.Setup(manager, dataManager.GetPlayerDataForLevel(0));
        asteroidControllerObject = Instantiate(asteroidControllerPrefab);
        asteroidController = asteroidControllerObject.GetComponent<AsteroidController>();
        asteroidController.Setup(manager, asteroidsData);
        asteroidController.CreateNewAsteroids(asteroidsData.GetStartingAmount());
    }

    private void OnAsteroidDestroyedEvent(object sender, EventArgs e)
    {
        AsteroidDestroyedEvent asteroidDestroyedEvent = (AsteroidDestroyedEvent)e;
        AsteroidBehaviour asteroidBehaviour = asteroidDestroyedEvent.hitAsteroid;
        
        if (asteroidBehaviour.stage >= asteroidsData.GetNumberOfStages())
        {
            score += gameData.GetPointsForDestroyingAsteroids();
            asteroidsDestroyedCount++;
            if (asteroidsDestroyedCount % gameData.GetPowerupFrequency()==0) 
            {
                CreatePowerup(asteroidBehaviour.transform.position);
            }
        }
    }

    private void OnPlayerDeadEvent(object sender, EventArgs e)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnMenuPressed(InputAction.CallbackContext obj)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void CreatePowerup(Vector3 position) 
    { 
        int powerupIndex=Random.Range(0, powerupPrefabs.Length);
        GameObject powerUp = Instantiate(powerupPrefabs[powerupIndex]);
        powerUp.transform.position = position;
        BasePowerup powerupBehaviour=powerUp.GetComponent<BasePowerup>();
        powerupBehaviour.Setup(manager);
    }

    private void OnDestroy()
    {
        StopListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
        StopListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
    }
}

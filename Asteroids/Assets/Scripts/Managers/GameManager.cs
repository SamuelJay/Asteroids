using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : Manager
{
    public int score { get; private set; }
    public int playerHealth => playerBehaviour.health;
    public InputActions inputActions { get; private set; }
    
    [SerializeField] private AsteroidsData asteroidsData;
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject asteroidControllerPrefab;
    [SerializeField] private GameObject[] powerupPrefabs;

  

    private int asteroidsDestroyedCount;
    private int progressCount;
    private GameObject playerObject;
    private GameObject asteroidControllerObject;
    private AsteroidController asteroidController;
    private PlayerBehaviour playerBehaviour; 
    private AppManager appManager => manager as AppManager;
    private DataManager dataManager=> appManager.dataManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;
    private UIManager uiManager => appManager.uiManager;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);

        StartListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
        StartListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);

        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.AppControls.Menu.performed += OnMenuPressed;
        uiManager.SetupGameUI();
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
        Debug.Log($"GameManger OnAsteroidDestroyedEvent{asteroidBehaviour.stage}");
        if (asteroidBehaviour.stage >= asteroidsData.GetNumberOfStages())
        {
            score += gameData.GetPointsForDestroyingAsteroids();
            asteroidsDestroyedCount++;
            Debug.Log($"GameManger OnAsteroidDestroyedEvent asteroidsDestroyedCount {asteroidsDestroyedCount} numberOfAsteroidsAfterSplits {asteroidController.numberOfAsteroidsAfterSplits}");
            int powerupCheck = asteroidsDestroyedCount % gameData.GetPowerupFrequency();
            if (powerupCheck == 0) 
            {
                CreatePowerup(asteroidBehaviour.transform.position);
            }
            if (asteroidsDestroyedCount >= asteroidController.numberOfAsteroidsAfterSplits)
            {
                progressCount++;
                asteroidController.CreateNewAsteroids(asteroidsData.GetStartingAmount() + (asteroidsData.GetIncreaseAmount() * progressCount));
                asteroidsDestroyedCount = 0;
            }
        }
    }

    private void OnExitButtonPressedEvent(object sender, EventArgs e)
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
        Destroy(powerUp, 10f);
    }

    private void OnDestroy()
    {
        StopListeningToEvent<ExitButtonPressedEvent>(OnExitButtonPressedEvent);
        StopListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyedEvent);
        inputActions.AppControls.Menu.performed -= OnMenuPressed;
    }

   
}

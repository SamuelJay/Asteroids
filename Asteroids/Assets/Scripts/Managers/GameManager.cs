using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    public InputActions inputActions { get; private set; }
    [SerializeField] private AsteroidsData asteroidsData;
    [SerializeField] private GameObject playerPrefab;
    private GameObject playerObject;
    private PlayerBehaviour playerBehaviour; 
    [SerializeField] private GameObject asteroidControllerPrefab;
    private GameObject asteroidControllerObject;
    private AsteroidController asteroidController;
    private AppManager appManager => manager as AppManager;
    private DataManager dataManager=> appManager.dataManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);

        StartListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);

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

    private void OnPlayerDeadEvent(object sender, EventArgs e)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnMenuPressed(InputAction.CallbackContext obj)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

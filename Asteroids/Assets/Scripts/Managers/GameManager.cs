using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject playerObject;
    private PlayerBehaviour playerBehaviour;

    private AppManager appManager => manager as AppManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;
    private InputActions inputActions;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.AppControls.Menu.performed += OnMenuPressed;

        playerObject = Instantiate(playerPrefab);
        playerBehaviour = playerObject.GetComponent<PlayerBehaviour>();
        playerBehaviour.Setup(manager);
    }

    private void OnMenuPressed(InputAction.CallbackContext obj)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    private AppManager appManager => manager as AppManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;
    private InputActions inputActions;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.AppControls.Menu.performed += OnMenuPressed;
    }

    private void OnMenuPressed(InputAction.CallbackContext obj)
    {
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

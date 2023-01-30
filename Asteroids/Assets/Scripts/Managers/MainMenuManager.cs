using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Manager
{
    private AppManager appManager => manager as AppManager;
    private SceneLoadingManager sceneLoadingManager => appManager.sceneLoadingManager;  
    private UIManager uiManager => appManager.uiManager;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        StartListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
        uiManager.SetupMainMenuUI();

    }

    private void OnStartButtonPressedEvent(object sender, EventArgs e)
    {
        sceneLoadingManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        StopListeningToEvent<StartButtonPressedEvent>(OnStartButtonPressedEvent);
    }
}

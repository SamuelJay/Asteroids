using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager
{
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public GameManager gameManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }
    public EventManager eventManager { get; private set; }
    public UIManager uiManager { get; private set; }

    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;
    [SerializeField] private GameObject eventManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;

    private GameObject sceneLoadingManagerObject;
    private GameObject gameManagerObject;
    private GameObject mainMenuManagerObject;
    private GameObject eventManagerObject;
    private GameObject uiManagerObject;

    private void Awake()
    {
        Setup(this);
        DontDestroyOnLoad(this);
        sceneLoadingManagerObject = Instantiate(sceneLoadingManagerPrefab);
        eventManagerObject = Instantiate(eventManagerPrefab);
        uiManagerObject = Instantiate(uiManagerPrefab);

        DontDestroyOnLoad(sceneLoadingManagerObject);
        DontDestroyOnLoad(eventManagerObject);
        DontDestroyOnLoad(uiManagerObject);

        sceneLoadingManager = sceneLoadingManagerObject.GetComponent<SceneLoadingManager>();
        eventManager = eventManagerObject.GetComponent<EventManager>();
        uiManager = uiManagerObject.GetComponent<UIManager>();

        sceneLoadingManager.Setup(this);
        eventManager.Setup(this);
        uiManager.Setup(this);

        StartListeningToEvent<SceneLoadedEvent>(OnSceneLoadedEvent);
        sceneLoadingManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
    }

    private void SetupMainMenuScene()
    {
        mainMenuManagerObject = Instantiate(mainMenuManagerPrefab);
        mainMenuManager = mainMenuManagerObject.GetComponent<MainMenuManager>();
        mainMenuManager.Setup(this);
    }

    private void SetupGameScene()
    {
        gameManagerObject = Instantiate(gameManagerPrefab);
        gameManager = gameManagerObject.GetComponent<GameManager>();
        gameManager.Setup(this);
    }

    private void OnSceneLoadedEvent(object sender, EventArgs e)
    {
        SceneLoadedEvent sceneLoadedEvent = (SceneLoadedEvent)e;
         switch (sceneLoadedEvent.scene.name)
        {
            case "MainMenu": SetupMainMenuScene(); 
                break;
            case "Game": SetupGameScene();
                break;
        };
    }
}
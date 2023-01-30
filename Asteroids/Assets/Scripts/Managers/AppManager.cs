using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Manager
{
    public EventManager eventManager { get; private set; }
    public DataManager dataManager { get; private set; }
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public GameManager gameManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }

    [SerializeField] private GameObject eventManagerPrefab;
    [SerializeField] private GameObject dataManagerPrefab;
    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject uiManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;

    private GameObject eventManagerObject;
    private GameObject dataManagerObject;
    private GameObject sceneLoadingManagerObject;
    private GameObject uiManagerObject;
    private GameObject mainMenuManagerObject;
    private GameObject gameManagerObject;

    private void Awake()
    {
        Setup(this);
        DontDestroyOnLoad(this);
        eventManagerObject = Instantiate(eventManagerPrefab);
        dataManagerObject = Instantiate(dataManagerPrefab);
        sceneLoadingManagerObject = Instantiate(sceneLoadingManagerPrefab);
        uiManagerObject = Instantiate(uiManagerPrefab);

        DontDestroyOnLoad(eventManagerObject);
        DontDestroyOnLoad(dataManagerObject);
        DontDestroyOnLoad(sceneLoadingManagerObject);
        DontDestroyOnLoad(uiManagerObject);

        eventManager = eventManagerObject.GetComponent<EventManager>();
        dataManager = dataManagerObject.GetComponent<DataManager>();
        sceneLoadingManager = sceneLoadingManagerObject.GetComponent<SceneLoadingManager>();
        uiManager = uiManagerObject.GetComponent<UIManager>();

        eventManager.Setup(this);
        dataManager.Setup(this);
        sceneLoadingManager.Setup(this);
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
    private void OnDestroy()
    {
        StopListeningToEvent<SceneLoadedEvent>(OnSceneLoadedEvent);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Manager
{
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public GameManager gameManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }

    public EventManager eventManager { get; private set; }

    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;
    [SerializeField] private GameObject eventManagerPrefab;

    private GameObject sceneLoadingManagerObject;
    private GameObject gameManagerObject;
    private GameObject mainMenuManagerObject;
    private GameObject eventManagerObject;

    private void Awake()
    {
        Setup(this);
        DontDestroyOnLoad(this);
        sceneLoadingManagerObject = Instantiate(sceneLoadingManagerPrefab);
        gameManagerObject = Instantiate(gameManagerPrefab);
        mainMenuManagerObject = Instantiate(mainMenuManagerPrefab);
        eventManagerObject = Instantiate(eventManagerPrefab);

        DontDestroyOnLoad(sceneLoadingManagerObject);
        DontDestroyOnLoad(gameManagerObject);
        DontDestroyOnLoad(mainMenuManagerObject);
        DontDestroyOnLoad(eventManagerObject);

        sceneLoadingManager = sceneLoadingManagerObject.GetComponent<SceneLoadingManager>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
        mainMenuManager = mainMenuManagerObject.GetComponent<MainMenuManager>();
        eventManager = eventManagerObject.GetComponent<EventManager>();

        sceneLoadingManager.Setup(this);
        gameManager.Setup(this);
        mainMenuManager.Setup(this);
        eventManager.Setup(this);
    }

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
    }
}

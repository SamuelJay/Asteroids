using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Manager
{
    public SceneLoadingManager sceneLoadingManager { get; private set; }
    public GameManager gameManager { get; private set; }
    public MainMenuManager mainMenuManager { get; private set; }

    [SerializeField] private GameObject sceneLoadingManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;
    [SerializeField] private GameObject mainMenuManagerPrefab;

    private GameObject sceneLoadingManagerObject;
    private GameObject gameManagerObject;
    private GameObject mainMenuManagerObject;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        sceneLoadingManagerObject = Instantiate(sceneLoadingManagerPrefab);
        gameManagerObject = Instantiate(gameManagerPrefab);
        mainMenuManagerObject = Instantiate(mainMenuManagerPrefab);

        DontDestroyOnLoad(sceneLoadingManagerObject);
        DontDestroyOnLoad(gameManagerObject);
        DontDestroyOnLoad(mainMenuManagerObject);

        sceneLoadingManager = sceneLoadingManagerObject.GetComponent<SceneLoadingManager>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
        mainMenuManager = mainMenuManagerObject.GetComponent<MainMenuManager>();

/*        sceneLoadingManager.Setup(this);
        gameManager.Setup(this);
        mainMenuManager.Setup(this);*/
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : Manager
{
    [SerializeField] GameObject mainMenuCanvasPrefab;

    private GameObject mainMenuCanvasObject;
    private MainMenuCanvasController mainMenuCanvasController;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        mainMenuCanvasObject = Instantiate(mainMenuCanvasPrefab);
        mainMenuCanvasController = GetComponent<MainMenuCanvasController>();
        mainMenuCanvasController.Setup(manager);
    }
}

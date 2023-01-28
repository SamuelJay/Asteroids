using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager
{
    [SerializeField] private GameObject mainMenuCanvasPrefab;
    private GameObject mainMenuCanvasObject;
    private MainMenuCanvasController mainMenuCanvasController;
    
    public override void Setup(Manager manager)
    {
        base.Setup(manager);
    }

    public void SetupMainMenuUI() 
    {
        mainMenuCanvasObject = Instantiate(mainMenuCanvasPrefab);
        mainMenuCanvasController = mainMenuCanvasObject.GetComponent<MainMenuCanvasController>();
        mainMenuCanvasController.Setup(manager);
    }

    public void SetupGameUI()
    {

    }
}

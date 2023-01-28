using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class MainMenuCanvasController : Controller
{
    [SerializeField] private Button startButton;


    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        startButton.onClick.AddListener(StartButtonPressed);
    }

    private void StartButtonPressed()
    {
        TriggerEvent<StartButtonPressedEvent>(new StartButtonPressedEvent());
    }
}

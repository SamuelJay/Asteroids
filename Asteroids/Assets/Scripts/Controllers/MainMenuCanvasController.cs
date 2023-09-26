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
   /* [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip startGameSound;*/

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        startButton.onClick.AddListener(StartButtonPressed);
    }

    public void StartButtonPressed()
    {
      /*  audioSource.PlayOneShot(startGameSound);
        Invoke("LoadGameScene", startGameSound.length);*/
        TriggerEvent<StartButtonPressedEvent>(new StartButtonPressedEvent());
    }
}

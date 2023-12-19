using System.Collections;
using System.Collections.Generic;
//#if UNITY_EDITOR
using UnityEngine;
//#endif
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class MainMenuCanvasController : Controller
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button muteButton;
   /* [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip startGameSound;*/

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        startButton.onClick.AddListener(StartButtonPressed);
        muteButton.onClick.AddListener(MuteButtonPressed);
    }

    private void MuteButtonPressed() {
       TriggerEvent<MuteButtonPressedEvent>(new MuteButtonPressedEvent());
    }

    public void StartButtonPressed()
    {
      /*  audioSource.PlayOneShot(startGameSound);
        Invoke("LoadGameScene", startGameSound.length);*/
        TriggerEvent<StartButtonPressedEvent>(new StartButtonPressedEvent());
    }

    public void Exit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private Button exitButton;
    private AppManager appManager=> manager as AppManager;
    private GameManager gameManager=> appManager.gameManager;
    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        StartListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
        exitButton.onClick.AddListener(ExitButtonPressed);
    }

    private void ExitButtonPressed()
    {
        TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
    }

    private void Update()
    {
        scoreText.text = $"Score:{gameManager.score}"; 
    }
    private void OnPlayerDeadEvent(object sender, EventArgs e)
    {
        gameOverPopup.SetActive(true);
        gameOverScoreText.text = $"Score:{gameManager.score}";

        StopListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
    }
}

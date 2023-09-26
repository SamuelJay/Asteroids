using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : BaseBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;

    [SerializeField] private AudioClip[] gameMusic;
    private AudioSource audioSource;
    private AppManager appManager=> manager as AppManager;
    private GameManager gameManager=> appManager.gameManager;
    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        StartListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
        exitButton.onClick.AddListener(ExitButtonPressed);
        AudioSetUp();
    }

    private void ExitButtonPressed()
    {
        TriggerEvent<ExitButtonPressedEvent>(new ExitButtonPressedEvent());
    }

    private void AudioSetUp() {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic[UnityEngine.Random.Range(0, gameMusic.Length)];
        audioSource.Play();
    }

    private void Update()
    {
        scoreText.text = $"Score:{gameManager.score}"; 
        healthText.text = $"Health: {gameManager.playerHealth}";
        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log("P pressed");
            PauseGame();
        }
    }
    private void OnPlayerDeadEvent(object sender, EventArgs e)
    {
        gameOverPopup.SetActive(true);
        gameOverScoreText.text = $"Score:{gameManager.score}";

        StopListeningToEvent<PlayerDeadEvent>(OnPlayerDeadEvent);
    }

    public void PauseGame() {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            //game slows down to zero speed
            Time.timeScale = 0;
        } else
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            //game plays at normal speed
            Time.timeScale = 1;
        }
    }
}

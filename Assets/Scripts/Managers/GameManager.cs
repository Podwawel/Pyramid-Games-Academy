using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton, tryAgainButton;
    [SerializeField] private GameObject keyInventory, keyInInventory, keyFrameInInventory;
    [SerializeField] private GameObject timerObject, highscoreObject, currentScoreObject;
    [SerializeField] private DataContainer dataContainer;
    [SerializeField] private GameSetup gameSetup;
    [SerializeField] private GameOver gameOver;
    private TextMeshProUGUI timerText, highscoreText, currentScoreText;
    private float gameplayTimer;

    private Action gameplayTimerExecute;
    private void Start()
    {
        timerText = timerObject.GetComponent<TextMeshProUGUI>();
        highscoreText = highscoreObject.GetComponent<TextMeshProUGUI>();
        currentScoreText = currentScoreObject.GetComponent<TextMeshProUGUI>();

        highscoreText.text = "Highscore: " + PlayerPrefs.GetString("Highscore");

        gameplayTimer = 0;
        dataContainer.IsKeyCollected = false;

        gameSetup.StartGameplayEvent += GameSetup_PrepareObjectsVisibility;
        gameSetup.StartGameplayEvent += GameSetup_StartGameplayTimer;

        gameOver.FinishGameplayEvent += GameOver_FinishGame;
        gameOver.FinishGameplayEvent += GameOver_TryAgainMenu;
    }

    private void Update()
    {
        if (gameplayTimerExecute != null) gameplayTimerExecute();
        if (dataContainer.IsKeyCollected) ChangeKeyInventory();
    }

    private void GameplayTimerCount()
    {
        gameplayTimer += Time.deltaTime;
        timerText.text = FormatTime();
    }
    private string FormatTime()
    {
        int d = (int)(gameplayTimer * 100.0f);
        int seconds = d/100;
        int hundredths = d % 100;
        return String.Format("{0:00}:{1:00}", seconds, hundredths);
    }

    private void GameSetup_StartGameplayTimer()
    {
        gameplayTimer = 0;
        gameplayTimerExecute += GameplayTimerCount;
    }

    private void GameSetup_PrepareObjectsVisibility()
    {
        currentScoreObject.SetActive(false);
        highscoreObject.SetActive(false);
        startButton.SetActive(false);
        tryAgainButton.SetActive(false);

        timerObject.SetActive(true);
        keyInventory.SetActive(true);
        keyFrameInInventory.SetActive(true);
    }
    private void GameOver_FinishGame()
    {
        gameplayTimerExecute -= GameplayTimerCount;
        dataContainer.CurrentScore = gameplayTimer;
        if (dataContainer.CurrentScore < PlayerPrefs.GetFloat("HighscoreFloat") || PlayerPrefs.GetFloat("HighscoreFloat") == 0)
        {
            PlayerPrefs.SetString("Highscore", FormatTime());
            PlayerPrefs.SetFloat("HighscoreFloat", gameplayTimer);
        }
        highscoreText.text = "Highscore: " + PlayerPrefs.GetString("Highscore");
    }

    private void GameOver_TryAgainMenu()
    {
        dataContainer.IsKeyCollected = false;
        timerObject.SetActive(false);
        keyInventory.SetActive(false);
        keyInInventory.SetActive(false);

        tryAgainButton.SetActive(true);
        currentScoreObject.SetActive(true);
        highscoreObject.SetActive(true);

        currentScoreText.text = "Current score: " + FormatTime();
    }

    private void ChangeKeyInventory()
    {
        keyFrameInInventory.SetActive(false);
        keyInInventory.SetActive(true);
    }
}

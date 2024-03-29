using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class CanvasManager : Singleton<CanvasManager>
{

    public TextMeshProUGUI playerScore, finalScore, fpsLimitText, mouseSensitivityText, fpsText;
    public TextMeshProUGUI comboText, soundPercentText, playerHighScoreText;
    [SerializeField] public float countDown;
    [SerializeField] private Slider count;
    [SerializeField] private GameObject gameCanvas, menuCanvas, gameFinishCanvas;
    [SerializeField] private float smoothness = 0.1f, currentFPS;

    private void Start()
    {
        countDown = LevelManager.Instance.GetLevel().countDown;
        UiTextUpdate();
        CanvasChanger();
        SetSliderMaxValueAndValue();
    }

    private void Update()
    {
        if (LevelManager.Instance.GetLevel().gameStatus == GameStatus.Started)
        {
            LevelCountDownUpdate();
        }

        CalculateFps();
    }

    public void UiTextUpdate()
    {
        playerScore.text = $"Score: {PlayerManager.Instance.GetPlayer().score}";
        fpsLimitText.text = SettingsManager.Instance.GetChoosenFps() == 0 ? "Fps: No Limit" : $"Fps: {SettingsManager.Instance.GetChoosenFps()}";
        mouseSensitivityText.text = $"Mouse Sensitivity: %{SettingsManager.Instance.GetMouseSensivityPercent()}";
        comboText.text = PlayerManager.Instance.GetPlayer().combo != 0 ? $"Combo {PlayerManager.Instance.GetPlayer().combo}X" : "";
        soundPercentText.text = $"Sound: %{SettingsManager.Instance.GetSoundPercent()}";;
        playerHighScoreText.text = $"Best Score: {PlayerManager.Instance.GetPlayerHighScore()}";
    }


    private void SetSliderMaxValueAndValue()
    {
        count.maxValue = countDown;
        count.value = countDown;
    }

    public void ResetCount()
    {
        count.value = countDown;
    }

    public float GetCount()
    {
        return count.value;
    }

    private void LevelCountDownUpdate()
    {
        if (count.value <= 0)
        {
            LevelManager.Instance.GameFinished();
            finalScore.text = $"Your Score: {PlayerManager.Instance.GetPlayer().score}";
            PlayerController.Instance.ShowTargetToPlayer();
        }
        count.value -= Time.deltaTime;
    }

    public void CanvasChanger()
    {
        switch (LevelManager.Instance.GetLevel().gameStatus)
        {
            case GameStatus.Started:
                gameCanvas.SetActive(true);
                menuCanvas.SetActive(false);
                gameFinishCanvas.SetActive(false);
                break;
            case GameStatus.Finished:
                gameCanvas.SetActive(false);
                menuCanvas.SetActive(false);
                gameFinishCanvas.SetActive(true);
                break;
            default:
                gameCanvas.SetActive(false);
                menuCanvas.SetActive(true);
                gameFinishCanvas.SetActive(false);
                break;
        }
    }

    private void CalculateFps()
    {
        float instantFPS = 1.0f / Time.deltaTime;
        currentFPS = Mathf.Lerp(currentFPS, instantFPS, smoothness);
        fpsText.text = "FPS: " + Mathf.RoundToInt(currentFPS);
    }
}
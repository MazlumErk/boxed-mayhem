using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    [SerializeField] private Slider mouseSensitivitySlider;
    [System.NonSerialized][SerializeField] private List<int> fpsLimits = new() { 30, 60, 75, 120, 144, 240, 0 };
    [SerializeField] private int choosenFps;
    [SerializeField] private GameObject settingsMenu;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // 75
        choosenFps = fpsLimits[2];
        Application.targetFrameRate = choosenFps;
        SetSliderValues();
    }

    private void SetSliderValues()
    {
        mouseSensitivitySlider.maxValue = 9f;
        mouseSensitivitySlider.minValue = 0.1f;
        mouseSensitivitySlider.value = 2;
    }

    private void SetFps()
    {
        Application.targetFrameRate = choosenFps;
    }

    public void ChangeMouseSensitivity()
    {
        PlayerController.Instance.SetMouseSensitivity(mouseSensitivitySlider.value);
    }

    public void IncreaseFps()
    {
        int choosenFpsIndex = fpsLimits.IndexOf(choosenFps);
        if (choosenFpsIndex == fpsLimits.Count - 1)
        {
            choosenFps = fpsLimits[0];
        }
        else
        {
            choosenFps = fpsLimits[choosenFpsIndex + 1];
        }
        SetFps();
    }

    public void DecreaseFps()
    {
        int choosenFpsIndex = fpsLimits.IndexOf(choosenFps);
        if (choosenFpsIndex == 0)
        {
            choosenFps = fpsLimits[fpsLimits.Count - 1];
        }
        else
        {
            choosenFps = fpsLimits[choosenFpsIndex - 1];
        }
        SetFps();
    }

    public int GetChoosenFps()
    {
        return choosenFps;
    }

    public float GetMouseSensivityPercent()
    {
        return Convert.ToInt32((mouseSensitivitySlider.value / mouseSensitivitySlider.maxValue) * 100);
    }

    public void SettingsMenuOpenClose()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }
}
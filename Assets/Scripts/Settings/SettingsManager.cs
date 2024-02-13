using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SettingsManager : Singleton<SettingsManager>
{
    [SerializeField] private SettingsManagerType settingsManagerType;
    [SerializeField] private Slider mouseSensitivitySlider, soundPercentSlider;
    [SerializeField] private List<AudioSource> audioSources;
    private List<int> fpsLimits = new() { 30, 60, 75, 120, 144, 240, 0 };
    [SerializeField] private GameObject settingsMenu;

    private void Start()
    {
        mouseSensitivitySlider.value = settingsManagerType.choosenMouseSensivity;
        Application.targetFrameRate = settingsManagerType.choosenFps;
        SetSliderValues();
    }

    private void SetSliderValues()
    {
        mouseSensitivitySlider.value = settingsManagerType.choosenMouseSensivity;
        soundPercentSlider.value = settingsManagerType.choosenSoundPercent;
    }

    private void SetFps()
    {
        Application.targetFrameRate = settingsManagerType.choosenFps;
    }

    public void ChangeMouseSensitivity()
    {
        settingsManagerType.choosenMouseSensivity = mouseSensitivitySlider.value;
        PlayerController.Instance.SetMouseSensitivity(mouseSensitivitySlider.value);
    }

    public void ChangeSoundPercent()
    {
        settingsManagerType.choosenSoundPercent = soundPercentSlider.value;
        for (int i = 0; i < audioSources.Count; i++)
        {
            audioSources[i].volume = soundPercentSlider.value;
        }
    }

    public void IncreaseFps()
    {
        int choosenFpsIndex = fpsLimits.IndexOf(settingsManagerType.choosenFps);
        if (choosenFpsIndex == fpsLimits.Count - 1)
        {
            settingsManagerType.choosenFps = fpsLimits[0];
        }
        else
        {
            settingsManagerType.choosenFps = fpsLimits[choosenFpsIndex + 1];
        }
        SetFps();
    }

    public void DecreaseFps()
    {
        int choosenFpsIndex = fpsLimits.IndexOf(settingsManagerType.choosenFps);
        if (choosenFpsIndex == 0)
        {
            settingsManagerType.choosenFps = fpsLimits[fpsLimits.Count - 1];
        }
        else
        {
            settingsManagerType.choosenFps = fpsLimits[choosenFpsIndex - 1];
        }
        SetFps();
    }

    public int GetChoosenFps()
    {
        return settingsManagerType.choosenFps;
    }

    public float GetMouseSensivityPercent()
    {
        return Convert.ToInt32((mouseSensitivitySlider.value / mouseSensitivitySlider.maxValue) * 100);
    }

    public float GetSoundPercent()
    {
        return Convert.ToInt32((soundPercentSlider.value / soundPercentSlider.maxValue) * 100);
    }

    public void SettingsMenuOpenClose()
    {
        settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
    }
}
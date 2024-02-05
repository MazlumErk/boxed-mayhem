using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider mouseSensitivitySlider;

    private void Start()
    {
        mouseSensitivitySlider.maxValue = 9f;
        mouseSensitivitySlider.minValue = 0.1f;
        mouseSensitivitySlider.value = 2;
    }

    public void ChangeMouseSensitivity()
    {
        PlayerController.Instance.SetMouseSensitivity(mouseSensitivitySlider.value);
    }
}
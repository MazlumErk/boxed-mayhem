using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SettingsManagerType", menuName = "Manager/SettingsManagerType")]
public class SettingsManagerType : ScriptableObject
{
    public float choosenMouseSensivity;
    public float choosenSoundPercent;
    public List<int> fpsLimits = new() { 30, 60, 75, 120, 144, 240, 0 };
    public int choosenFps;
    public GameObject settingsMenu;
}

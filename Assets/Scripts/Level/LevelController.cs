using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void StartGame()
    {
        LevelManager.Instance.SetLevel(GameStatus.Started);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CanvasManager.Instance.CanvasChanger();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

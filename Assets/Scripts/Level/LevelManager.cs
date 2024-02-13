using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // public static LevelManager Instance;
    [SerializeField] private Level level;
    [SerializeField] private AudioSource audioSource;

    // private void Awake()
    // {
    //     Instance = this;
    // }

    public Level GetLevel()
    {
        return level;
    }

    public void SetLevel(GameStatus newGameStatus)
    {
        level = new Level()
        {
            countDown = level.countDown,
            targetCount = level.targetCount,
            gameStatus = newGameStatus,
        };
    }

    public void GameFinished()
    {
        LevelManager.Instance.SetLevel(GameStatus.Finished);
        PlayerManager.Instance.SetPlayerHighScore(PlayerManager.Instance.GetPlayer().score);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        CanvasManager.Instance.CanvasChanger();
        audioSource.Play();
    }
}
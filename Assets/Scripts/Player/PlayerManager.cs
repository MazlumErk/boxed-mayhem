using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerManagerType playerManagerType;
    private Player player;

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayerHighScore(int newHighScore)
    {
        playerManagerType.playerHighScore = playerManagerType.playerHighScore < newHighScore ? newHighScore : playerManagerType.playerHighScore;
    }

    public void SetPlayer(int? newScore = null, int? newCombo = null)
    {
        player = new Player()
        {
            score = newScore == null ? player.score : newScore.Value,
            combo = newCombo == null ? player.combo : newCombo.Value,
        };
    }

    public int GetPlayerHighScore()
    {
        return playerManagerType.playerHighScore;
    }
}

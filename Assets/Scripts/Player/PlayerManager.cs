using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private Player player;

    private void Awake()
    {
        Instance = this;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayer(int? newScore = null, int? newCombo = null)
    {
        player = new Player()
        {
            score = newScore == null ? player.score : newScore.Value,
            combo = newCombo == null ? player.combo : newCombo.Value,
        };
    }
}

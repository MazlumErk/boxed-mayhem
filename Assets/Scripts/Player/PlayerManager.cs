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

    public void SetPlayer(int? newScore = null)
    {
        player = new Player()
        {
            score = newScore == null ? player.score : newScore.Value,
        };
    }
}

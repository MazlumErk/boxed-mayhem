using System;

[Serializable]
public struct Level
{
    public int countDown;
    public int targetCount;
    public GameStatus gameStatus;
}

[Serializable]
public enum GameStatus
{
    NotStarted,
    Started,
    Finished,
    Pause,
}
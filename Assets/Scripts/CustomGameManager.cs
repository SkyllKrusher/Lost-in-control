using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    INTRO,
    PLAY,
    OVER
}

public class CustomGameManager : MonoBehaviour
{
    public static CustomGameManager Instance;
    public GameState currentGameState = GameState.INTRO;
    public int currentLevel = 0;
    public bool isFTUE = true;

    void Awake()
    {
        if (CustomGameManager.Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
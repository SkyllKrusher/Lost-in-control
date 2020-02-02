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
    public bool isLeftBroken = false;
    public bool isRightBroken = false;
    public bool isJumpBroken = false;
    public static CustomGameManager Instance;
    public GameState currentGameState = GameState.INTRO;
    public int currentLevel = 0;
    public bool isFTUE = true;
    public bool playerHasKey;

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
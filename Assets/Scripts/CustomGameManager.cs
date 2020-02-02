using UnityEngine;
using UnityEngine.UI;
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
    public GameObject[] Buttons;
    public Sprite btn;
    public Sprite btnDestroy;
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
    public void ChangeButtonSprite(bool doDestroy, int btnIndex)
    {
        // 0 = Left, 1 = Right, 2 = Jump
        if (doDestroy)
        {
            Buttons[btnIndex].GetComponent<Image>().sprite = btnDestroy;
        }
        else
        {
            Buttons[btnIndex].GetComponent<Image>().sprite = btn;
        }
    }
}
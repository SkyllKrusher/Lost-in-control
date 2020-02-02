using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameView gameView;

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (CustomGameManager.Instance.playerHasKey == true)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        int currentLevel = CustomGameManager.Instance.currentLevel;
        gameView.DoLevelTransition(currentLevel, currentLevel + 1, false);
    }
}

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
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        Debug.LogWarning("------------ Open Door --------------------");

        int currentLevel = CustomGameManager.Instance.currentLevel;
        Debug.LogError("Current level = " + currentLevel + "Next level = " + (currentLevel + 1));
        // StartCoroutine(gameView.StartLevelTransition(currentLevel, currentLevel + 1, false));
        gameView.DoLevelTransition(currentLevel, currentLevel + 1, false);
    }
}

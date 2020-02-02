using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CollectKey();
        }
    }

    private void CollectKey()
    {
        Debug.Log("Collecting Keys");
        CustomGameManager.Instance.playerHasKey = true;
        HandleControlEnabled();
        DisableKey();
    }

    private void DisableKey()
    {
        gameObject.SetActive(false);
    }

    private void HandleControlEnabled()
    {
        switch (CustomGameManager.Instance.currentLevel)
        {
            case (0):
                {
                    AudioManager.Instance.PlayButtonRecoverSound();
                    // do nothing
                    //Debug.LogError("Case 0 !");
                    break;
                }

            case (1):
                {
                    AudioManager.Instance.PlayButtonRecoverSound();
                    //Debug.LogError("Stting for lvl 1 btn status...");
                    CustomGameManager.Instance.isLeftBroken = true;
                    CustomGameManager.Instance.isRightBroken = false;
                    CustomGameManager.Instance.isJumpBroken = false;
                    CustomGameManager.Instance.ChangeButtonSprite(true, 0);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 1);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 2);
                    break;
                }

            case (2):
                {
                    AudioManager.Instance.PlayButtonRecoverSound();
                    //Debug.LogError("Stting for lvl 1 btn status...");
                    CustomGameManager.Instance.isLeftBroken = false;
                    CustomGameManager.Instance.isRightBroken = false;
                    CustomGameManager.Instance.isJumpBroken = false;
                    CustomGameManager.Instance.ChangeButtonSprite(false, 0);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 1);
                    CustomGameManager.Instance.ChangeButtonSprite(false, 2);
                    break;
                }

            case (3):
                {
                    // TODO
                    break;
                }

            default:
                {
                    // do nothing
                    break;
                }
        }
    }
}

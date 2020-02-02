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
        DisableKey();
    }

    private void DisableKey()
    {
        gameObject.SetActive(false);
    }
}

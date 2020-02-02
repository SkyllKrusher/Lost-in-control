using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformPlayerAttach : MonoBehaviour
{
    [SerializeField] private Transform levelTransform;
    private Transform selfTransform;

    private void start()
    {
        selfTransform = transform;
    }

    private void AttachPlayerToPlatform(GameObject player)
    {
        player.transform.SetParent(transform);
    }

    private void DetachPlayerFromPlatform(GameObject player)
    {
        player.transform.parent = null;
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttachPlayerToPlatform(other.gameObject);
        }
    }

    private void HandleTriggerExit(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DetachPlayerFromPlatform(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HandleTriggerExit(other);
    }
}

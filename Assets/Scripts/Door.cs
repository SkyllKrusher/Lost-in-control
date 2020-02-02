using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool hasKey;

    private void Start()
    {
        //has key = manager value
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleTriggerEnter(other);
    }

    private void HandleTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hasKey == true)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
        //manager next scene
    }
}

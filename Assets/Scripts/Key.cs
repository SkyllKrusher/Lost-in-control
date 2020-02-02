using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

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
        //manager has key bool = true;
    }
}

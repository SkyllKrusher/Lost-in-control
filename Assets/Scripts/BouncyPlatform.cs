using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] private Transform endProjectilePoint = null;
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.LogError("Collided with = " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHandler>().StartPlayerBounce(endProjectilePoint);
        }
    }
}

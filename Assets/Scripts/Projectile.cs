using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{

    //[Tooltip("Position we want to hit")]
    [HideInInspector]
    public Transform targetTransform;

    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = 1;

    [Tooltip("Do we need to face the same direction or the opposite?")]
    public bool faceSameDir = true;
    public PlayerHandler player;

    Vector3 startPos;

    void OnEnable()
    {
        // Cache our start position, which is really the only thing we need
        // (in addition to our current position, and the target).
        startPos = transform.position;
    }

    void Update()
    {
        // Compute the next position, with arc added in
        float x0 = startPos.x;
        float x1 = targetTransform.position.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetTransform.position.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Rotate to face the next position, and then move there
        if (faceSameDir)
        {
            transform.rotation = LookAt2D(nextPos - transform.position);
        }
        else
        {
            transform.rotation = LookAt2D(transform.position - nextPos);
        }
        transform.position = nextPos;

        // Do something when we reach the target
        if (nextPos == targetTransform.position) Arrived();
    }

    void Arrived()
    {
        //Debug.LogError("TADA! Arrived!");
        player.PlayerBounceComplete(targetTransform.position);
        //Destroy(gameObject);
    }

    /// 
    /// This is a 2D version of Quaternion.LookAt; it returns a quaternion
    /// that makes the local +X axis point in the given forward direction.
    /// 
    /// forward direction
    /// Quaternion that rotates +X to align with forward
    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
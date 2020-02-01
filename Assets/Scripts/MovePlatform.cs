using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform startTransform;
    [Space]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveRange = 3.2f;
    [Space]
    [SerializeField] private bool isMoveX = true;
    [SerializeField] private bool isMoveY = false;
    // [SerializeField] private Transform positionB;

    void Start()
    {
        startTransform.position = platform.transform.position;
    }

    void Update()
    {
        OscillatePlatform();
    }
    private void OscillatePlatform()
    {
        float newPosition = -Mathf.Sin(Time.time * moveSpeed) * moveRange;
        platform.transform.position = startTransform.position + new Vector3(newPosition * (isMoveX ? 1 : 0), newPosition * (isMoveY ? 1 : 0), 0.0f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private Animator playerControl;

    private void Start()
    {

    }

    public void StopControlAnimation()
    {
        playerControl.enabled = false;
    }
}
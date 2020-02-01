using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private Animator playerControl;
    [SerializeField] private Animator girlIntroAnimationControl;

    private void Start()
    {

    }

    public void StopControlAnimation()
    {
        playerControl.enabled = false;
    }

    public void StartGirlIntroAnimation()
    {
        girlIntroAnimationControl.Play("girlfall_intro");
    }
}
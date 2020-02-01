using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] soundClips;
    public AudioSource BgMusic;
    void Awake()
    {
        if (AudioManager.Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {

        //  BgMusic.Play();
    }
    public void PlayBgMusic()
    {
    }

    public void PlayerEnterJump()
    {

    }
    public void PlayerExitJump()
    {

    }
}

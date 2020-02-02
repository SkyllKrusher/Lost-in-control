using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] soundClips;
    public AudioClip[] bgMusic;
    public AudioSource BgMusic;
    void Awake()
    {
        if (Instance != null)
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
    public void PlayBgMusic1()
    {
        BgMusic.clip = bgMusic[0];
        BgMusic.Play();
    }
    public void PlayBgMusic2()
    {
        BgMusic.clip = bgMusic[1];
        BgMusic.Play();
    }

}

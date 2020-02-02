using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] soundClips;
    public AudioClip[] bgMusic;
    public AudioSource BgMusic;
    public AudioSource soundEffects;
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

    public void PlayEarthQuakeSound()
    {
        soundEffects.clip = bgMusic[3];
        soundEffects.Play();
    }
    public void PlayButtonRecoverSound()
    {
        soundEffects.clip = bgMusic[4];
        soundEffects.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicType : MonoBehaviour
{
    public string musicType;
    new public AudioManager audio;
    

    void Start()
    {
        audio = FindObjectOfType<AudioManager>();

        audio.playing(musicType);

        if(audio.isplaying == false && audio.currentMusic != musicType)
        {
            if (audio.currentMusic != "")
            {
                audio.Stop(audio.currentMusic);
            }
            audio.Play(musicType);
            audio.currentMusic = musicType;
        }


    }
}

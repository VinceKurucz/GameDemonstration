using UnityEngine;
using UnityEngine.Audio;
using System;

public class PlatAudio : MonoBehaviour
{
    public static PlatAudio instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    [HideInInspector]
    public bool isplaying;
    [HideInInspector]
    public bool isplaying2;
    public string currentMusic;

    void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.playOnAwake = s.playOnAwake;
            s.source.panStereo = s.stereo;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume; // * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch; // * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();

    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s != null)
        {
          
            s.source.Stop();
        }
    }

    public void playing(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s.source.isPlaying == true)
        {
            isplaying = true;
        }
        else
        {
            isplaying = false;
        }
    }

    public void playing2(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s.source.isPlaying == true)
        {
            isplaying2 = true;
        }
        else
        {
            isplaying2 = false;
        }
    }
}
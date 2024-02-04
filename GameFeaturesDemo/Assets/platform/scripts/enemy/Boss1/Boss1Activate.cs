using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss1Activate : MonoBehaviour
{
    [HideInInspector]
    public bool Start;

    public GameObject coll;
    public CinemachineConfiner confiner;

    public AudioSource music;
    public AudioSource musicEnd;

    private GameObject attack;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "PlatformPlayer")
        {  
            StartMusic();
            Start = true;
        }
    }

    private void OnDestroy()
    {

        if(GameObject.Find("Ray.2Right") || GameObject.Find("Ray.2") || GameObject.Find("Boss1Attack3"))
        {
            attack = FindObjectOfType<PlatformHurt>().gameObject;
        }

           
        if (attack != null)
        {
            attack.SetActive(false);
        }

        StopMusic();
        Destroy(coll);
        if (confiner != null)
        {
            confiner.enabled = false;
            if (musicEnd != null)
            {
                musicEnd.Play();
            }
        }
    }


    private void StartMusic()
    {
        if(music != null && music.isPlaying == false)
        {
            music.Play();
        }

    }
    private void StopMusic()
    {
        if (music != null)
        {
            music.Stop();
        }
    }
}

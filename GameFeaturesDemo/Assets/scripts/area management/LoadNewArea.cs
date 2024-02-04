using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNewArea : MonoBehaviour
{

    public string levelToLoad;

    public string exitpoint;
    private ControllerScript thePlayer;

    // To fix a bug with checkpoints
    public static bool notCheckpoint;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public GameObject obj;


    private bool playing;

    void Start()
    {
        thePlayer = FindObjectOfType<ControllerScript>();

        obj = GameObject.Find("ScreenFade");

        anim = obj.GetComponent<Animator>();

        

     
    }


     void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name=="Player")
        {
            anim.SetTrigger("FadeIn");
            notCheckpoint = true;

            if (isPlaying(anim, "ScreenFadeIn") == true)
            {
                SceneManager.LoadScene(levelToLoad);
                thePlayer.startPoint = exitpoint;
                anim.ResetTrigger("FadeIn");
            }
        }

    }
    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }


}

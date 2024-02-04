using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBack : MonoBehaviour
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

    private Manager manager;

    //to avoid the warning about 2 audio listeners in the same script
    private AudioListener audi;

    //Add points where to start
    public float posX;
    public float posY;

    void Start()
    {
        

        obj = GameObject.Find("ScreenFade");

        manager = FindObjectOfType<Manager>();

        anim = obj.GetComponent<Animator>();

        audi = FindObjectOfType<AudioListener>();

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "PlatformPlayer")
        {
            anim.SetTrigger("FadeIn");
            notCheckpoint = true;
            

            if (isPlaying(anim, "ScreenFadeIn") == true)
            {

                manager.LoadBack();
                thePlayer = FindObjectOfType<ControllerScript>();
                //   thePlayer.startPoint = exitpoint;
                thePlayer.transform.position = new Vector2(posX, posY);
                audi.gameObject.SetActive(false);
                SceneManager.LoadScene(levelToLoad);
                anim.ResetTrigger("FadeIn");

            }
        }

    }

    //I have no idea what happend here
    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }


}

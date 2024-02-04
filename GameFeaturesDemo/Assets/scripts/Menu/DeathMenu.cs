using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DeathMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject deathMenuUi;
    public GameObject AltdeathMenuUi;

    private PlayerHealthManager health;

    private DialogueMAnager dialogue;


    //TEST
    private Decisions dec;

    private string place;



    private void Start()
    {
        health = FindObjectOfType<PlayerHealthManager>();
        dec = FindObjectOfType<Decisions>();
        place = Application.persistentDataPath + "/Progress.file";
        dialogue = FindObjectOfType<DialogueMAnager>();

    }
    void Update()
    {
        
        if (health.playerCurrentHealth<=0)
        {
                Pause();             
        }
    }

    public void Resume()
    {       
        StopAllCoroutines();
        if (health.Hanim != null)
        {
            health.Hanim.gameObject.SetActive(true);
        }
        AudioListener.volume = 1f;
        deathMenuUi.SetActive(false);      
        gameIsPaused = false;
        Time.timeScale = 1f;
        health.Load();
        dec.Load();

        
        


    }
    void Pause()
    {
        if (health.Hanim != null)
        {
            health.Hanim.gameObject.SetActive(false);
        }

        AudioListener.volume = 0f;
 

        if (File.Exists(place) == true)
        {
            deathMenuUi.SetActive(true);
            StartCoroutine(wait());
            gameIsPaused = true;
        }
        else
        {
            AltdeathMenuUi.SetActive(true);
        }

        dialogue.EndDialogue();
    }

    public void Quit()
    {
        Application.Quit();
    }


    private IEnumerator wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Time.timeScale = 0f;   
        }
        
    }
}


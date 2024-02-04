using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [HideInInspector]
    public GameObject UI;
    [HideInInspector]
    public GameObject Player;
    [HideInInspector]
    public GameObject Camera;
    [HideInInspector]
    private PlayerHealthManager healt;
    [HideInInspector]
    public GameObject audioManager;

    public static Manager instance;

    //idk what is this
    [HideInInspector]
    public bool first;

    public void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        


        UI = GameObject.Find("Canvas");
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("CamHolder");
        audioManager = GameObject.Find("Audio Manager");
        healt = FindObjectOfType<PlayerHealthManager>();
        

        
    }

    public void PlatformLoad()
    {
        audioManager.SetActive(false);
        UI.SetActive(false);
        Player.SetActive(false);
        Camera.SetActive(false);
    }

    public void LoadBack()
    {

        audioManager.SetActive(true);
        UI.SetActive(true);
        Player.SetActive(true);
        Camera.SetActive(true);


    }

    public void PlatformDeath()
    {

        audioManager.SetActive(true);
        UI.SetActive(true);
        Player.SetActive(true);
        Camera.SetActive(true);
        SceneManager.LoadScene("LoadScene");
        healt.Load();
        FindObjectOfType<Decisions>().Load();

    }


}

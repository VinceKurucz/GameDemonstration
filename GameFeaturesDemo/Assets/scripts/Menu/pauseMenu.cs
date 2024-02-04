using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;

    new public AudioManager audio;

    private void Start()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused == true)
            {
                Resume();
            }
            else if(gameIsPaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;



        audio.Stop("FloorRun");
        audio.Stop("ForestRun");
        audio.Stop("GravelRun");
        audio.Stop("HitSound");

    }

    public void Quit()
    {
        Application.Quit();
    }
}

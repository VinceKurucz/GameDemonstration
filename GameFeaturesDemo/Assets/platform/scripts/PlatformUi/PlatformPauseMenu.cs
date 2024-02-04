using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;

    new public PlatAudio audio;

    private void Start()
    {
        audio = FindObjectOfType<PlatAudio>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else if (gameIsPaused == false)
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
        audio.Stop("Run");

    }

    public void Quit()
    {
        Application.Quit();
    }
}

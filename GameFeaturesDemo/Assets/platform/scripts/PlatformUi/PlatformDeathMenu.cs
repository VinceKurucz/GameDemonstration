using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeathMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject deathMenuUi;

    private PlatformPlayerHealth health;

    private void Start()
    {
        health = FindObjectOfType<PlatformPlayerHealth>();
    }
    void Update()
    {

        if (health.playerCurrentHealth <= 0)
        {
            Pause();
        }
    }

    public void Resume()
    {
        deathMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        health.Load();

    }
    void Pause()
    {
        deathMenuUi.SetActive(true);
        FindObjectOfType<platformMovement>().enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

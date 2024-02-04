using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformUiManager : MonoBehaviour
{
    public Slider HealthBar;
    public Text Hptext;
    public PlatformPlayerHealth PlayerHealth;
    private static bool PlatuiExists;

    /*
    void Start()
    {
        if (!PlatuiExists)
        {
            PlatuiExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */
    void FixedUpdate()
    {
        HealthBar.maxValue = PlayerHealth.playerMaxHealth;
        HealthBar.value = PlayerHealth.playerCurrentHealth;
        Hptext.text = "HP: " + PlayerHealth.playerCurrentHealth + "/" + PlayerHealth.playerMaxHealth;
    }
}

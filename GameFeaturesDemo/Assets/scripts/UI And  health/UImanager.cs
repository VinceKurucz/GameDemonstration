using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Slider HealthBar;
    public Text Hptext;
    public PlayerHealthManager PlayerHealth;
    private static bool uiExists;

  
    void Start()
    {
        if (!uiExists)
        {
            uiExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        HealthBar.maxValue = PlayerHealth.playerMaxHealth;
        HealthBar.value = PlayerHealth.playerCurrentHealth;
        Hptext.text = "HP: " + PlayerHealth.playerCurrentHealth + "/"+ PlayerHealth.playerMaxHealth;
    }
}

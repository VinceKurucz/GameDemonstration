using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlatformPlayerHealth : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;

    // for an other script I guess?
    public static int med;

    // to set the position of the player when loaded
    private Rigidbody2D rb2d;
    public const string saveSeparator = "#Save-Value#";

    // camera shake
    public CameraShake cameraShake;
    // how long we want the camera to shake
    private float time;

    // life potions
    public int numberOfMeds;
    public int currentNumberOfMeds;

    // animation for flashing when med is used
    public Animator anim;

    // animation for red flashing when hurt...
    public Animator Hanim;

    private Manager manager;

    private AudioListener audi;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        rb2d = GetComponent<Rigidbody2D>();

        manager = FindObjectOfType<Manager>();

        audi = FindObjectOfType<AudioListener>();

        //    Load();
        //Loadnig Progress
        //  FindObjectOfType<Decisions>().Load();
        //    Destroy(FindObjectOfType<NewGame>().gameObject);




        //Loadnig Progress
        // FindObjectOfType<Decisions>().Load();


        currentNumberOfMeds = numberOfMeds;
        time = 0f;
    }


    private void FixedUpdate()
    {



        if (playerCurrentHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            AudioListener.volume = 0;

            playerCurrentHealth = 0;

            if (time < 30f)
            {
                StartCoroutine(cameraShake.Shake(.14f, .4f));
                time++;
            }
            else
            {
                StopAllCoroutines();
            }
        }
        else
        {
            time = 0f;
        }

        med = numberOfMeds;
    }
        void Update()
    {

    if (Input.GetButtonDown("Heal") && currentNumberOfMeds != 0 && playerCurrentHealth > 0)
        {
            playerCurrentHealth = playerMaxHealth;
            currentNumberOfMeds -= 1;
            anim.SetFloat("start", 2f);
        }
        if (Input.GetButtonUp("Heal"))
        {
            anim.SetFloat("start", 0f);
        }

    }
    public void hurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        if (Hanim != null)
        {
            Hanim.SetFloat("Start", 2f);
        }
    }
    public void StopHurt()
    {
        if (Hanim != null)
        {
            Hanim.SetFloat("Start", 0f);
        }
    }
    public void setMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Load (coding 404)
    public void Load()
    {
        AudioListener.volume = 1;
        audi.gameObject.SetActive(false);
        manager.PlatformDeath();

        /*
        string msaveString = File.ReadAllText(Application.persistentDataPath + "/msave.file");

        int saveMed = int.Parse(msaveString);


        //these are only needed if the player is dead
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<ControllerScript>().enabled = true;
        gameObject.SetActive(true);



        numberOfMeds = saveMed;
        setMaxHealth();

        string psaveString = File.ReadAllText(Application.persistentDataPath + "/psave.file");

        string[] pcontents = psaveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);


        float playerPositionX = float.Parse(pcontents[0]);
        float playerPositionY = float.Parse(pcontents[1]);



        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY);

        rb2d.position = playerPosition;


        string SsaveString = File.ReadAllText(Application.persistentDataPath + "/Ssave.file");
        SceneManager.LoadScene(SsaveString);
        */
    }

    void newLoad()
    {
        string msaveString = File.ReadAllText(Application.persistentDataPath + "/NEWmsave.file");

        int saveMed = int.Parse(msaveString);


        //these are only needed if the player is dead
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<ControllerScript>().enabled = true;
        gameObject.SetActive(true);



        numberOfMeds = saveMed;
        setMaxHealth();

        string psaveString = File.ReadAllText(Application.persistentDataPath + "/NEWpsave.file");

        string[] pcontents = psaveString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);


        float playerPositionX = float.Parse(pcontents[0]);
        float playerPositionY = float.Parse(pcontents[1]);



        Vector3 playerPosition = new Vector3(playerPositionX, playerPositionY);

        rb2d.position = playerPosition;


        string SsaveString = File.ReadAllText(Application.persistentDataPath + "/NEWSsave.file");
        SceneManager.LoadScene(SsaveString);
    }

}

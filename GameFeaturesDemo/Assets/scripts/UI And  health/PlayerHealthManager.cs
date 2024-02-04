using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
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

    private Decisions dec;
    public GameObject robot;
    


    // animation for flashing when med is used
    public Animator anim;

    // animation for red flashing when hurt...
    public Animator Hanim;

    private Manager manager;

    [HideInInspector]
    public bool newgame;

    private AudioManager audioman;

    bool hurting = false;
    bool playing = false;


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<Manager>();
        audioman = FindObjectOfType<AudioManager>();
        dec = FindObjectOfType<Decisions>();





        // Dont forget to activate these when the game is finished.

        if (FindObjectOfType<NewGame>().newGame == false)
        {
            Load();
            //Loadnig Progress
            FindObjectOfType<Decisions>().Load();
            Destroy(FindObjectOfType<NewGame>().gameObject);
        }
        else if (FindObjectOfType<NewGame>().newGame == true)
        {
            newLoad();
            newgame = true;
            Destroy(FindObjectOfType<NewGame>().gameObject);
        }


        //Loadnig Progress
        if (manager.first == false)
        {
            /*
            //also delete this
            FindObjectOfType<Decisions>().Load();
            //...and this
            Load();
            */
            manager.first = true;
        }

        currentNumberOfMeds = numberOfMeds;
        time = 0f;

        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Heal") && currentNumberOfMeds != 0 && playerCurrentHealth > 0 && pauseMenu.gameIsPaused == false)
        {
            playerCurrentHealth = playerMaxHealth;
            currentNumberOfMeds -= 1;
            anim.SetFloat("start", 2f);
        }
        if (Input.GetButtonUp("Heal"))
        {
            anim.SetFloat("start", 0f);
        }
        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        */
    }

    void FixedUpdate()
    {
     

        if (playerCurrentHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
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

        if(hurting == true && playing == false)
        {
            audioman.Play("HitSound");
            hurting = false;
            playing = true;
        }





        if (dec.TakeRobot == true)
        {
            robot.SetActive(true);
        }
        else
        {
            robot.SetActive(false);
        }



    }
    public void hurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        if (Hanim != null)
        {
            Hanim.SetFloat("Start", 2f);
            hurting = true;    
        }
    }

    public void StopHurt()
    {
        if (Hanim != null)
        {
            Hanim.SetFloat("Start", 0f);
            audioman.Stop("HitSound");
            playing = false;
            hurting = false;
        }
    }
    public void setMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;

    }

    // Load 
    public void Load()
    {
        StopHurt();

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




        string progress = File.ReadAllText(Application.persistentDataPath + "/Progress.file");




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
        SceneManager.LoadScene("Facility");
    }


    /*
    public void savePlayer()
    {
        saveSystem.savePlayer(this);
    }
    public void loadPlayer()
    {
        playerData data = saveSystem.loadPlayer();

        playerCurrentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    */
    }

    

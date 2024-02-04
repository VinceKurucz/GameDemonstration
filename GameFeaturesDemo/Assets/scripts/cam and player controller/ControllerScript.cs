using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public  class ControllerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 moveVelocity;
    public Animator animator;

    private float movementSpeed;
    [HideInInspector]
    public Vector2 movementDirection;

    private static bool playerExists;

    public string startPoint;

    // to check if player is moving
    public static bool isMoving;

    // To save position and scene
    public static Vector3 Pos;
    public static Scene scene;

    //playing running sound
    new public AudioManager audio;

    //Checking the type of the ground we running on
    [HideInInspector]
    public bool dirt;
    [HideInInspector]
    public bool floor;
    [HideInInspector]
    public bool gravel;



    //with this we are checking if the player is currently in a conversation or dead (disabling the script does not working)
    [HideInInspector]
    public DialogueMAnager dial;
    [HideInInspector]
    public v2ChoiceManager choi;
    [HideInInspector]
    public PlayerHealthManager health;
    [HideInInspector]
    public RobotDialogueMAnager Rdial;




    private void Awake()
    {
        audio =  FindObjectOfType<AudioManager>();

        dirt = false;
        floor = false;
        gravel = false;

        // SceneManager.sceneLoaded += OnSceneLoaded;

    }
  /*
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ground = FindObjectOfType<groundType>();
    }
    */
        void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        dial = FindObjectOfType<DialogueMAnager>();
        choi = FindObjectOfType<v2ChoiceManager>();
        health = FindObjectOfType<PlayerHealthManager>();
        Rdial = FindObjectOfType<RobotDialogueMAnager>();
    }
  

    void Update()
    {
        moveVelocity.x = Input.GetAxisRaw("Horizontal");
        moveVelocity.y = Input.GetAxisRaw("Vertical");


        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        Animate();

        Pos = rb2d.transform.localPosition;
        scene = SceneManager.GetActiveScene();



        if (moveVelocity.y != 0f || moveVelocity.x != 0f)
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;         
        }

        
    }
    private void FixedUpdate()
    {

        if (dial.dialogueActive == false && choi.choiceActive == false && health.playerCurrentHealth > 0 && Rdial.dialogueActive == false)
        {
            rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);
        }

        if (scene.name != ("LoadScene"))
        {

            if (dial.dialogueActive == false && choi.choiceActive == false && Rdial.dialogueActive == false)
            {
                if (dirt == true)
                {
                    audio.Stop("FloorRun");
                    audio.Stop("GravelRun");
                }
                if (floor == true)
                {
                    audio.Stop("ForestRun");
                    audio.Stop("GravelRun");
                }
                if (gravel == true)
                {
                    audio.Stop("ForestRun");
                    audio.Stop("FloorRun");
                }

                if (movementDirection != Vector2.zero)
                {

                    if (dirt == true)
                    {
                        audio.playing2("ForestRun");

                        if (audio.isplaying2 == false)
                        {
                            audio.Play("ForestRun");
                        }

                    }
                    if (floor == true)
                    {
                        audio.playing2("FloorRun");

                        if (audio.isplaying2 == false)
                        {
                            audio.Play("FloorRun");
                        }
                    }
                    if (gravel == true)
                    {
                        audio.playing2("GravelRun");

                        if (audio.isplaying2 == false)
                        {
                            audio.Play("GravelRun");
                        }
                    }
                }
                else if (movementDirection == Vector2.zero)
                {
                    audio.Stop("FloorRun");
                    audio.Stop("ForestRun");
                    audio.Stop("GravelRun");
                }

            }
            else
            {
                audio.Stop("FloorRun");
                audio.Stop("ForestRun");
                audio.Stop("GravelRun");
            }

            //For unknow reasons running sounds keep on playing when pause menu is activated, this is a solution.         
            if (Time.timeScale == 0f)
            {
                audio.Stop("ForestRun");
                audio.Stop("FloorRun");
                audio.Stop("GravelRun");
            }

        }

        /*
           if(moveVelocity.y > 0.1f)
          {
              animator.SetFloat("up", 0.2f);
              moveVelocity.y = 0f;
          }

          else if (moveVelocity.y < -0.1f)
          {
              animator.SetFloat("down", 0.2f);
              moveVelocity.y = 0f;
          }
           else if (moveVelocity.y == 0f)
          {
              animator.SetFloat("down", 0f);
              animator.SetFloat("up", 0f);
          }
          if (moveVelocity.x > 0.1f)
          {
              animator.SetFloat("right", 0.2f);
              moveVelocity.x = 0f;
          }

          else if (moveVelocity.x < -0.1f)
          {
              animator.SetFloat("left", 0.2f);
              moveVelocity.x = 0f;
          }
          else if (moveVelocity.x == 0f)
          {
              animator.SetFloat("right", 0f);
              animator.SetFloat("left", 0f);
          }

          */
    }



    //Animation happens here

    void Animate()
    {

        if (dial.dialogueActive == false && choi.choiceActive == false && Rdial.dialogueActive == false)
        {
            if (movementDirection != Vector2.zero)
            {
                animator.SetFloat("horizontal", moveVelocity.x);
                animator.SetFloat("vertical", moveVelocity.y);
            }


            animator.SetFloat("speed", movementSpeed);


            /*
             //Taking out the attack from the game 
             
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetFloat("attack", 1f);

            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                animator.SetFloat("attack", 0f);

            }
            */
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

    }

    private void OnDisable()
    {
        animator.SetFloat("speed", 0f);

        if (rb2d != null)
        {
            rb2d.MovePosition(rb2d.position + moveVelocity * 0);
        }

        audio.Stop("FloorRun");
        audio.Stop("ForestRun");
        audio.Stop("GravelRun");
    }




}

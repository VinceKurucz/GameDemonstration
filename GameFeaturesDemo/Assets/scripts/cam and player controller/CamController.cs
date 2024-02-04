using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;
    private static bool cameraExists;

    private ControllerScript controll;

    public GameObject Right;
    public GameObject Left;
    public GameObject Up;
    public GameObject Down;

    [HideInInspector]
    public DialogueMAnager dial;
    [HideInInspector]
    public v2ChoiceManager choi;
    [HideInInspector]
    public RobotDialogueMAnager Rdial;

    private float state = 1;


    void Start()
    {

        dial = FindObjectOfType<DialogueMAnager>();
        Rdial = FindObjectOfType<RobotDialogueMAnager>();
        choi = FindObjectOfType<v2ChoiceManager>();

        controll = FindObjectOfType<ControllerScript>();

        DontDestroyOnLoad(gameObject);

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Update()
    {
        

        if (dial.dialogueActive == false && choi.choiceActive == false && Time.timeScale != 0 && Rdial.dialogueActive == false)
        {
            if (controll.movementDirection.x > 0.1f)
            {
                state = 1;
            }
            else if (controll.movementDirection.x < -0.1f)
            {
                state = 2;
            }
            else if (controll.movementDirection.y == 1f)
            {
                state = 3;
            }
            else if (controll.movementDirection.y == -1f)
            {
                state = 4;
            }



            if(state == 1)
            {
                targetPosition = new Vector3(Right.transform.position.x, Right.transform.position.y, transform.position.z);
            }
            else if(state == 2)
            {
                targetPosition = new Vector3(Left.transform.position.x, Left.transform.position.y, transform.position.z);
            }
            else if (state == 3)
            {
                targetPosition = new Vector3(Up.transform.position.x, Up.transform.position.y, transform.position.z);
            }
            else if (state == 4)
            {
                targetPosition = new Vector3(Down.transform.position.x, Down.transform.position.y, transform.position.z);
            }


         //     targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

        }
    }
}

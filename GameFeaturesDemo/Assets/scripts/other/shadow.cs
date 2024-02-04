using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shadow : MonoBehaviour
{


    private Vector3 vec;

    //to get new position
    private Vector3 curVel;
    private Vector3 curVelx;

    //to get direction

    public Animator animator;

    private ControllerScript controller;

    private RobotDialogueMAnager Rdial;

    void Start()
    {
        vec = transform.position;
        controller = FindObjectOfType<ControllerScript>();
        Rdial = FindObjectOfType<RobotDialogueMAnager>();
    }

    void Update()
    {

        

        curVelx = gameObject.transform.position;
        curVel = curVelx - vec;
        vec = transform.position;

        //(curVel.y > 0 && curVel.x == 0);

        if (controller.dial.dialogueActive == false && controller.choi.choiceActive == false && Rdial.dialogueActive == false)
        {

            if (controller.movementDirection != Vector2.zero && controller.moveVelocity.y > 0)
            {
                transform.localPosition = new Vector3(0f, -0.09f);
                animator.SetFloat("speed", 1f);

            }
            else if (controller.movementDirection != Vector2.zero && controller.moveVelocity.y < 0)
            {
                transform.localPosition = new Vector3(0f, -0.1f);
                animator.SetFloat("speed", 1f);

            }

            if (controller.movementDirection != Vector2.zero && controller.moveVelocity.x > 0)
            {
                transform.localPosition = new Vector2(0.015f, -0.1f);
                animator.SetFloat("speed", 1f);
            }
            else if (controller.movementDirection != Vector2.zero && controller.moveVelocity.x < 0)
            {

                transform.localPosition = new Vector3(-0.015f, -0.1f);
                animator.SetFloat("speed", 1f);
            }

            if (curVel.y == 0 && curVel.x == 0)
            {
                animator.SetFloat("speed", 0f);
            }

        }
    }

}

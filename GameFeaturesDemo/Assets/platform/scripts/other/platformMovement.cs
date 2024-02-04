using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour 
{
    public CharacterController2D Controller;

    float HorizontalMove = 0f;

    float RunSpeed = 20f;

    bool Jump = false;
    bool Crouch = false;

    private DialogueMAnager dial;

    private void Start()
    {
        dial = FindObjectOfType<DialogueMAnager>();
    }

 
    void Update()
    {


            HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                Jump = true;
            }
            if (Input.GetButtonDown("Crouch"))
            {
                Crouch = true;
            }

            else if (Input.GetButtonUp("Crouch"))
            {
                Crouch = false;
            }
        
    }
    private void FixedUpdate()
    {


            if (dial.dialogueActive == false)
            {

                Controller.Move(HorizontalMove * Time.fixedDeltaTime, Crouch, Jump);
                Jump = false;

            }
            else
            {
                Controller.Move(0f, false, false);
            }
        
    }
        

}

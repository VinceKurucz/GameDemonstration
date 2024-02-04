using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundType : MonoBehaviour
{
    //checking what type of ground the player is currently on (others may will be added later)
    public bool isDirt;
    public bool isFloor;
    public bool isGravel;


    [HideInInspector]
    public ControllerScript runSound;

    private void Start()
    {
        runSound = FindObjectOfType<ControllerScript>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (isDirt == true)
            {
                runSound.dirt = true;
                runSound.floor = false;
                runSound.gravel = false;
            }
            else if (isFloor == true)
            {
                runSound.floor = true;
                runSound.dirt = false;
                runSound.gravel = false;
            }
            else if(isGravel == true)
            {
                runSound.gravel = true;
                runSound.floor = false;
                runSound.dirt = false;    
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (isDirt == true)
            {
                runSound.dirt = true;
                runSound.floor = false;
                runSound.gravel = false;
            }
            else if (isFloor == true)
            {
                runSound.floor = true;
                runSound.dirt = false;
                runSound.gravel = false;
            }
            else if (isGravel == true)
            {
                runSound.gravel = true;
                runSound.floor = false;
                runSound.dirt = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            runSound.dirt = false;
            runSound.floor = false;
            runSound.gravel = false;
        }
    }
    

    
}

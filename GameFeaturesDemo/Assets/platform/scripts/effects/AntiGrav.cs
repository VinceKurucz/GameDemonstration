using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGrav : MonoBehaviour
{
    public Rigidbody2D[] objects;

    private bool noGrav;
    private bool inZone;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "PlatformPlayer")
        {
            inZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PlatformPlayer")
        {
            inZone = false;
        }
    }

    private void Update()
    {
        if (inZone == true)
        {

            if (Input.GetButtonDown("Submit") && noGrav == true)
            {

                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].gravityScale = 1;

                }
            }
            if (Input.GetButtonUp("Submit") && noGrav == true && objects[0].gravityScale == 1)
            {
                noGrav = false;
            }

            if (Input.GetButtonDown("Submit") && noGrav == false)
            {

                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].gravityScale = -1;
                }
            }
            if (Input.GetButtonUp("Submit") && noGrav == false && objects[0].gravityScale == -1)
            {
                noGrav = true;
            }
        }

    }


}

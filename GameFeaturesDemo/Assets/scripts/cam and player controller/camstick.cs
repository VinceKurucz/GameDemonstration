using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camstick : MonoBehaviour
{

    private CamController cam;
    private Vector2 vektor;

    private float speed;


    private void Start()
    {
        cam = FindObjectOfType<CamController>();
        speed = cam.moveSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            vektor = gameObject.transform.position;

            cam.moveSpeed = 0;

            cam.gameObject.transform.position = vektor;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.enabled = true;
            cam.moveSpeed = speed;
        }
    }

    private void OnDestroy()
    {
        if (cam != null)
        {
            cam.moveSpeed = speed;
        }
    }


}

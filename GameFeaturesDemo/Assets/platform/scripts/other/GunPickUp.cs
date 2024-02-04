using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Sprite pickedUp;
    private SpriteRenderer render;

    private void Start()
    {

        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name=="PlatformPlayer")
        {
            if (Input.GetButtonDown("Submit"))
            {
                FindObjectOfType<weapon>().charged = true;
                render.sprite = pickedUp;
            }
        }
    }
}

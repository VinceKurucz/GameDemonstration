using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGrounded : MonoBehaviour
{
    private CharacterController2D controller;

    private void Start()
    {
        controller = FindObjectOfType<CharacterController2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "PlatformPlayer")
        {
            if (controller != null)
            {
                controller.m_Grounded = true;
            }
        }
    }

}

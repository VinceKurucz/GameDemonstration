using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform1 : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.SetFloat("Down", 1f);
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetFloat("Down", 0f);
        }
    }
}

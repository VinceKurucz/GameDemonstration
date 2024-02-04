using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle2 : MonoBehaviour
{
    private Decisions dec;
    public GameObject block;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "PlatformPlayer")
        {
            dec = FindObjectOfType<Decisions>();
            if(dec.TakeRobot == true)
            {
                block.SetActive(false);
            }
        }

    }
}
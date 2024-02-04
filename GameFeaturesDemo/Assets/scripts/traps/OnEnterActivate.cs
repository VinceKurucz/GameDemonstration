using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterActivate : MonoBehaviour
{
    public GameObject ToActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name =="Trigger")
        {
            ToActivate.SetActive(true);
        }
    }
}

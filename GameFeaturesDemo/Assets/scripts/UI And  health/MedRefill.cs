using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedRefill : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().currentNumberOfMeds = other.gameObject.GetComponent<PlayerHealthManager>().numberOfMeds;
        }
    }
}

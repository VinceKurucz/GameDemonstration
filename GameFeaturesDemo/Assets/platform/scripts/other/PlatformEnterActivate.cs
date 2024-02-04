using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnterActivate : MonoBehaviour
{
    public string Character;
    public GameObject ToActivate;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == Character)
        {
            if (Character != null)
            {
                ToActivate.SetActive(true);
            }
        }
    }

}

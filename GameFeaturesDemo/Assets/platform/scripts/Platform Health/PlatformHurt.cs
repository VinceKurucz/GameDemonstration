using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHurt : MonoBehaviour
{
    public int damageToGive;

    //stonks
    private PlatformPlayerHealth helt;

    private void Start()
    {
        helt = FindObjectOfType<PlatformPlayerHealth>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "PlatformPlayer")
        {
            
            other.gameObject.GetComponent<PlatformPlayerHealth>().hurtPlayer(damageToGive);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlatformPlayer")
        {
            other.gameObject.GetComponent<PlatformPlayerHealth>().StopHurt();

        }
    }

    private void OnDestroy()
    {
        if (helt != null)
        {
            helt.StopHurt();
        }      
    }
    private void OnDisable()
    {
        if (helt != null)
        {
            helt.StopHurt();
        }
    }

}


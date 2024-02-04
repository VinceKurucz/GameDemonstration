using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerConstant : MonoBehaviour
{
    public int damageToGive;

    private PlayerHealthManager health;
  



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().hurtPlayer(damageToGive);
         
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().StopHurt();

        }
    }

    private void OnDisable()
    {
        health = FindObjectOfType<PlayerHealthManager>();

        if(health != null)
        {
            health.StopHurt();
        }
    }
}


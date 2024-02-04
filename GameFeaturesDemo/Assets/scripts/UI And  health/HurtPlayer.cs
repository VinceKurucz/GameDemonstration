using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;
    private int time;

    // Update is called once per frame
    void Update()
    {
        time++;
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && time > 100)
        {
            other.gameObject.GetComponent<PlayerHealthManager>().hurtPlayer(damageToGive);
            time = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().StopHurt();

        }
    }
}

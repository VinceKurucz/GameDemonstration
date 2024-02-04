using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [HideInInspector]
    public bool InColl;
    [HideInInspector]
    public bool Dmg;

    public Enemy enemy;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.isTrigger == false)
        {
            InColl = true;


            enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Dmg = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.isTrigger == false)
        {
            InColl = false;

            Dmg = false;
            enemy = null;
        }

    }
}

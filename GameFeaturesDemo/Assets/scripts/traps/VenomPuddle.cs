using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomPuddle : MonoBehaviour
{
    public CircleCollider2D damage;

    public void damageOn()
    {
        damage.enabled = true;
    }
    public void damageOff()
    {
        damage.enabled = false;
    }


}

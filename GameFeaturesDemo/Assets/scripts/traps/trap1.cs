using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap1 : MonoBehaviour
{
    public GameObject toActivate;

    public void Active()
    {
        toActivate.SetActive(true);
    }

    public void deActive()
    {
        toActivate.SetActive(false);
    }

}

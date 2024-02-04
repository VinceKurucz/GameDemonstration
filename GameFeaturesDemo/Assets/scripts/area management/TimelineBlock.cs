using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineBlock : MonoBehaviour
{

    // E
    private void Start()
    {
        FindObjectOfType<ControllerScript>().enabled = false;
    }

    private void OnDisable()
    {
        FindObjectOfType<ControllerScript>().enabled = true;
    }


}

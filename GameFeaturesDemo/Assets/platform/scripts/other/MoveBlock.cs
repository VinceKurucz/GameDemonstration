using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private platformMovement move;

    void Start()
    {
        move = FindObjectOfType<platformMovement>();
        move.enabled = false;
    }


    private void OnDisable()
    {
        if (move != null)
        {
            move.enabled = true;
        }
    }

}

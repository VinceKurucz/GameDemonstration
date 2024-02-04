using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private ControllerScript thePlayer;
    private CamController theCamera;
   

    public Vector2 startDirection;

    public string pointName;

    void Start()
    {
        thePlayer = FindObjectOfType<ControllerScript>();

        if (thePlayer == true && thePlayer.startPoint == pointName && LoadNewArea.notCheckpoint == true)
        {
            LoadNewArea.notCheckpoint = false;
            thePlayer.transform.position = transform.position;
            thePlayer.movementDirection = startDirection;
        }
        theCamera = FindObjectOfType<CamController>();
        if (theCamera == true)
        {
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }


}

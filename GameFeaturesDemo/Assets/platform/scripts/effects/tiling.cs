using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class tiling : MonoBehaviour
{
    public int offsetX = 2;

    public bool hasARight = false;
    public bool hasALeft = false;

    public bool ReversScale = false;

    private float SpriteWith = 0f;

    private Camera cam;
    private Transform mytransform;


      void Awake()
    {
        cam = Camera.main;
        mytransform = transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer Srenderer = GetComponent<SpriteRenderer>();

        SpriteWith = Srenderer.sprite.bounds.size.x;


    }

    // Update is called once per frame
    void Update()
    {
        if (hasALeft == false || hasARight == false)
        {
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            float VisiblePositionRight = (mytransform.position.x + SpriteWith / 2) - camHorizontalExtend;
            float VisiblePositionLeft = (mytransform.position.x - SpriteWith / 2) + camHorizontalExtend;



            if (cam.transform.position.x >= VisiblePositionRight - offsetX && hasARight == false)
            {
                MakeNew (1);
                hasARight = true; 

            }
            else if (cam.transform.position.x <= VisiblePositionLeft + offsetX && hasALeft == false)
            {
                MakeNew(-1);
                hasALeft = true;

            }
        }
    }
    void MakeNew (int RightOrLeft)
    {
        Vector3 NewPosition = new Vector3(mytransform.position.x + SpriteWith * RightOrLeft, mytransform.position.y, mytransform.position.z);
        Transform newBuddy = Instantiate(mytransform, NewPosition, mytransform.rotation) as Transform;

        if(ReversScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);

        }

        newBuddy.parent = mytransform.parent;
        if(RightOrLeft > 0)
        {
            newBuddy.GetComponent<tiling>().hasALeft = true;
        }
        else
        {
            newBuddy.GetComponent<tiling>().hasARight = true;
        }
    }
}

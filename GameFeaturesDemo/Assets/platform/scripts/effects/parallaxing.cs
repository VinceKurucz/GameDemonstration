using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxing : MonoBehaviour

{ 
    public Transform[] backgrouds;
    public float[] parallaxscales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 PrevCamPos;

    public bool forthground;

    private void Awake()
    {
        cam = Camera.main.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        PrevCamPos = cam.position;

        parallaxscales = new float[backgrouds.Length];

        for (int i = 0; i < backgrouds.Length; i++)
        {
            if(forthground == false)
            {
                parallaxscales[i] = backgrouds[i].position.z * -1;
            }
            else if(forthground == true)
            {
                parallaxscales[i] = backgrouds[i].position.z * 7;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrouds.Length; i++)
        {
            float parallax = (PrevCamPos.x - cam.position.x) * parallaxscales[i];

            float BackGroundTargetPosX = backgrouds[i].position.x + parallax;

            Vector3 BackgooundTargetPos = new Vector3(BackGroundTargetPosX, backgrouds[i].position.y, backgrouds[i].position.z);

            backgrouds[i].position = Vector3.Lerp(backgrouds[i].position, BackgooundTargetPos, smoothing * Time.deltaTime);
        }

        PrevCamPos = cam.position;
    }
}

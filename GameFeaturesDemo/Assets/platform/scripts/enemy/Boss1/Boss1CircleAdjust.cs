using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boss1CircleAdjust : MonoBehaviour
{

    public CircleCollider2D circle;

    //shaking the object
    public CameraShake cameraShake;

    //camera shaking
    private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noise;
    private GameObject camer;


    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();

        //shaking the object
        StartCoroutine(cameraShake.Shake(.4f, .1f));


        //camera shaking

        camer = GameObject.Find("CM vcam1");

        cam = camer.GetComponent<CinemachineVirtualCamera>();

        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        

    }

    public void noCircle()
    {
        circle.radius = 0f;     
    }

    public void CircleSmol()
    {
        circle.radius = 0.08f;
        //shaking the object
        StopAllCoroutines();
        //camera shaking
        noise.m_FrequencyGain = 0.003f;
    }


    public void CircleMedium()
    {
        circle.radius = 0.15f;
        //camera shaking
        noise.m_FrequencyGain = 0.8f;
    }


    public void CircleBig()
    {
        circle.radius = 0.19f;       
    }

}

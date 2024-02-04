using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;

    //original speed
    private float oSpeed;

    //target
    public Transform target;

    //old position
    private Vector3 vec;

    //to get new position
    private Vector3 curVel;
    private Vector3 curVelx;

    //to get direction
    private Vector3 direction;

    public Animator animator;
    
    void Start()
    {
        //what to follow
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //old speed
        oSpeed = speed;

        //old position
        vec = transform.position;
       
    }
    // To make it slow down when attacked
    private void FixedUpdate()
    {
        speed = oSpeed;       
    }


    void LateUpdate()
    {

        //to tell which direction the enemy moving
        curVelx = gameObject.transform.position;
        curVel = curVelx - vec;
        direction = curVel.normalized;
        vec = transform.position;
        /*
        if (curVel.y > 0)
        {
            
            animator.SetFloat("vertical", direction.y);
           
        }
        else if(curVel.y < 0)
        {
           
            animator.SetFloat("vertical", direction.y);           
        }

        if (curVel.x > 0)
        {
            
            animator.SetFloat("horizontal", direction.x);

        }
        else if (curVel.x < 0)
        {
            
            animator.SetFloat("horizontal", direction.x);
        }
        animator.SetFloat("speed", speed);

        */

        // This to follow

        
        if (Vector2.Distance(transform.position, target.position) > 10)
        {
            gameObject.transform.position = target.transform.position;
        }
        
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
        

        
    }
}

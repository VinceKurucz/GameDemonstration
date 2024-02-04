using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowV2 : MonoBehaviour
{

    //The only diference between this and the original follow script, that this reqires to be in a range before starts following 

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

    public Range range;

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


    void Update()
    {

        //to tell which direction the enemy moving
        curVelx = gameObject.transform.position;
        curVel = curVelx - vec;
        direction = curVel.normalized;
        vec = transform.position;

        if (curVel.y > 0 && curVel.y != 0)
        {

            animator.SetFloat("vertical", direction.y);

        }
        else if (curVel.y < 0 && curVel.y != 0)
        {

            animator.SetFloat("vertical", direction.y);
        }

        if (curVel.x > 0 && curVel.x != 0)
        {

            animator.SetFloat("horizontal", direction.x);

        }
        else if (curVel.x < 0 && curVel.x != 0)
        {

            animator.SetFloat("horizontal", direction.x);
        }
        animator.SetFloat("speed", speed);

        // This to follow

        if(range.inRange == true)
        {
            if (Vector2.Distance(transform.position, target.position) > 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}

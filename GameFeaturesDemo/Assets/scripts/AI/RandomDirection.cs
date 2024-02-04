using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    public Rigidbody2D rb;


    //to get new position
    private Vector3 curVel;
    private Vector3 curVelx;

    //to get direction
    private Vector3 direction;

    //old position
    private Vector3 vec;

    public float speed;

    //original speed
    private float oSpeed;

    private Animator animator;

    public Transform center;

    public bool OutOfRange;

    public bool movingback;


    private void Start()
    {
      

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        //old speed
        oSpeed = speed;

        //old position
        vec = transform.position;

        StartCoroutine(wait());
  
    }


    void Update()
    {

        if (OutOfRange == true)
        {          
            movingback = true;
        }

        if(movingback == true)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, center.position, speed * Time.deltaTime);           
        }


            timeLeft -= Time.deltaTime;

            
            timeLeft += accelerationTime;
        
    }

    void FixedUpdate()
    {

        movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        speed = oSpeed;

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

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "center")
        {
            OutOfRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "center")
        {
            OutOfRange = false;
        }
    }

    private IEnumerator wait()
    {
        while(true)
        {
            if (movingback == true)
            {
                movingback = false;
            }

            if (OutOfRange == false && movingback == false)
            {
                rb.AddForce(movement * maxSpeed);
            }

            yield return new WaitForSeconds(Random.Range(1f,2f));

            if (OutOfRange == false && movingback == false)
            {
                rb.AddForce(movement * maxSpeed);
            }
            yield return new WaitForSeconds(Random.Range(1f, 2f));
           

        }
    }

    

}



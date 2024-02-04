using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroundedFollow : MonoBehaviour
{

    private Transform ToFollow;

    public float speed;

    private bool range;

    private Vector3 direction;

    private Rigidbody2D m_Rigidbody2D;

    private bool facingRight;

    //old position
    private Vector3 vec;

    //to get new position
    private Vector3 curVel;
    private Vector3 curVelx;

    void Start()
    {
        //what to follow

        ToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        //old position
        vec = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        curVelx = gameObject.transform.position;
        curVel = curVelx - vec;
        direction = curVel.normalized;
        vec = transform.position;


        if (range == true)
        {
            if (Vector2.Distance(transform.position, ToFollow.position) > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, ToFollow.position, speed * Time.deltaTime);
            }
        }



     

        if (direction.x > 0.5f && facingRight == false && direction.x != 0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
        else if(direction.x < 0.5f && facingRight == true &&  direction.x != 0f )
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            range = true;
        }
    }


}

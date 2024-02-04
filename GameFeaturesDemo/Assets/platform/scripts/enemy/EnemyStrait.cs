using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrait : MonoBehaviour
{
    private Rigidbody2D body;

    //seconds between each flip

    [SerializeField] private float SecondsToFlip = 1;

    //Add a small number...

    [SerializeField] private float speed = 1;

    private Vector2 LeftRight;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Flip());
        LeftRight.y = 0f;
        LeftRight.x = -1f;
    }

    void FixedUpdate()
    {
        //moving the rigidbody
        body.MovePosition(body.position + LeftRight * speed);
    }

    //Flipping using this simple coroutine
    IEnumerator Flip()
    {
        while(true)
        {
            yield return new WaitForSeconds(SecondsToFlip);

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            LeftRight.x = 1f;


            yield return new WaitForSeconds(SecondsToFlip);

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            LeftRight.x = -1f;
        }
    }  
}

//diabling the warning of the variables not being used
#pragma warning disable 0649
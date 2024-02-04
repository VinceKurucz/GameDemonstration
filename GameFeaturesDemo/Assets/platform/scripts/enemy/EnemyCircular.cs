using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircular : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 updown;

    public float SecondUp;
    public float SecondFlip;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(Flip());
        StartCoroutine(UpDown());
        updown.x = -1f;
        updown.y = -0.8f;
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + updown * Time.fixedDeltaTime);
    }

    IEnumerator Flip()
    {
        while (true)
        {
            yield return new WaitForSeconds(SecondFlip);

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            updown.x = 1f;

            yield return new WaitForSeconds(SecondFlip);

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            updown.x = -1f;
        }
        
    }

    IEnumerator UpDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(SecondUp);

            
            updown.y = 0.8f;

            yield return new WaitForSeconds(SecondUp);

           
            updown.y = -0.8f;

        }

    }
}

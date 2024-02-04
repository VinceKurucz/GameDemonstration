using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIcontroller : MonoBehaviour
{

    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    public float Speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        move();
    }
    void ProcessInputs()
    {
        
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

    }

    void move()
    {
        rb.velocity = movementDirection * movementSpeed * Speed;

    }
}

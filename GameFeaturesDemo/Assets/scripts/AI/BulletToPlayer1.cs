using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToPlayer1 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D Body;
    public float Speed = 3;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Body = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            Body.AddForce((player.transform.position - transform.position).normalized * Speed);
        }
    }

}

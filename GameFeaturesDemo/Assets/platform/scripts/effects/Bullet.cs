using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 20f;
    public Rigidbody2D Rb;
    public int Damage = 40;
    public GameObject ImpactEfffect;
    private FirePoint point;

    private void Awake()
    {
        point = FindObjectOfType<FirePoint>();

        if(point.InColl == true)
        {

            if(point.Dmg == true && point.enemy != null)
            {
                point.enemy.TakeDamage(Damage);
            }

            Instantiate(ImpactEfffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    void Start()
    {
        Rb.velocity = transform.right * Speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger == false)
        {
            Instantiate(ImpactEfffect, transform.position, transform.rotation);
            Destroy(gameObject);

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }

        }
    }




    }




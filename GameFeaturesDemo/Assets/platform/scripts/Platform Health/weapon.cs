using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour 
{

    public float ShootRate = 1f;
    public float BulletForce;

    public Transform FirePoint;

    public GameObject BulletPreFab;

    public Animator anim;

    public Animator TextAnimator;

    [HideInInspector]
    public bool charged;

    void Update()
    {

        
        if (charged == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // StartCoroutine(wait());
                animate();
                InvokeRepeating("Shoot", ShootRate, ShootRate);

            }
            else if (Input.GetButtonUp("Fire1"))
            {
                
                CancelInvoke("Shoot");
                anim.SetFloat("Shoot", 0f);
            }
        }
        else
        {
            if(Input.GetButtonDown("Fire1"))
            {
                TextAnimator.SetFloat("fadeIn", 2);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                TextAnimator.SetFloat("fadeIn", 0);
            }
        }
    }

    public void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPreFab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rib = Bullet.GetComponent<Rigidbody2D>();

        

        animate();
        rib.AddForce(FirePoint.right * BulletForce, ForceMode2D.Impulse);
    }

    void animate()
    {
        anim.SetFloat("Shoot", 1f);
    }
    IEnumerator wait()
    {
       while(true)
        {
            yield return new WaitForSeconds(0.1f);
            
            StopAllCoroutines();
           
        }
    }
}

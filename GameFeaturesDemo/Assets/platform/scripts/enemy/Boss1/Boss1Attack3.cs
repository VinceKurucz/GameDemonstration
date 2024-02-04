using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Attack3 : MonoBehaviour
{
    private Enemy health;
    private Animator anim;
    public GameObject middle;
    public GameObject attack3;



    void Start()
    {
        health = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        StartCoroutine(random());
    }

    public void elecroAttack()
    {
        Instantiate(attack3, middle.transform.position, middle.transform.rotation);
    }


    IEnumerator random()
    {
        while (true)
        {

            yield return new WaitForSeconds(4f);

            float rnd = Random.Range(1, 30);

            if (rnd <= 15 && health.health < 10000f)
            {

                anim.SetTrigger("Attack3");
            }

            yield return new WaitForSeconds(3f);
            
        }
    }
}

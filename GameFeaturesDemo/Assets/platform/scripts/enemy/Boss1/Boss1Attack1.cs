using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Attack1 : MonoBehaviour
{
    public GameObject ToInstantiate;

    public GameObject attack2;
    public GameObject attack2Right;


    public GameObject where;
    public GameObject where2;

    private Quaternion quat;



    private Animator anim;

    [HideInInspector]
    public Boss1Activate act;

    private void Start()
    {
        quat = where.transform.rotation;

    
        StartCoroutine(random());

        anim = GetComponent<Animator>();

        act = GetComponent<Boss1Activate>();


    }

    public void boom()
    {
        Instantiate(ToInstantiate, where.transform.position, quat);
    }
    public void Ray()
    {
        if (gameObject.transform.rotation.eulerAngles.y < 179)
        {
            Instantiate(attack2, where2.transform.position, quat);
        }
        if (gameObject.transform.rotation.eulerAngles.y >= 180)
        {

            Instantiate(attack2Right, where2.transform.position, quat);
        }
    }

    IEnumerator random()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            float rnd = Random.Range(1, 30);

            if(rnd <= 12 && act.Start == true)
            {
               
                anim.SetTrigger("Attack2");
            }

            yield return new WaitForSeconds(3f);

        }
    }


}

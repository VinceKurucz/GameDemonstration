using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class leafFall : MonoBehaviour
{
    public Animator anim;

    
    void FixedUpdate()
    {

       anim.SetFloat("time",Random.Range(0.2f, 1.6f));
      

    }
}

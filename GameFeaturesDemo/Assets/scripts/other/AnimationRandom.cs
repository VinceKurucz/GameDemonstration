using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRandom : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
      animator =  GetComponent<Animator>();
      animator.Update(Random.value);
    }


}

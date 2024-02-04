using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterAnimation : MonoBehaviour
{


    public Animator animator;

    public float seconds;

    private void Start()
    {
        if (FindObjectOfType<Decisions>().Phish == true)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Trigger")
        {
            animator.SetTrigger("Fade");
            FindObjectOfType<Decisions>().Phish = true;
            StartCoroutine(destory());
        }
    }


    private IEnumerator destory()
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }

}

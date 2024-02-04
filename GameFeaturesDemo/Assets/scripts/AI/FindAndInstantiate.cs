using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndInstantiate : MonoBehaviour
{
    public GameObject ToInstantiate;

    private bool waiting;
    private bool once;

    private Vector2 test;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(wait());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            test.y = other.attachedRigidbody.transform.position.y-0.5f;
            test.x = other.attachedRigidbody.transform.position.x;

            if (waiting == true && once == false)
            {
                Instantiate(ToInstantiate, test , other.attachedRigidbody.transform.rotation);
                once = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(wait());
        }
    }


    private IEnumerator wait()
    {
        while(true)
        {
            waiting = false;
            once = false;
            yield return new WaitForSeconds(1);
            waiting = true;
            yield return new WaitForSeconds(1);
        }

    }


}



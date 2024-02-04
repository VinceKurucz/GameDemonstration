using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour
{

    public GameObject ToInstantiate;

    private bool waiting;
    private bool once;

    public float seconds = 1;



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

            if (waiting == true && once == false)
            {
                Instantiate(ToInstantiate, gameObject.transform.position, gameObject.transform.rotation);
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
        while (true)
        {
            waiting = false;
            once = false;
            yield return new WaitForSeconds(seconds);
            waiting = true;
            yield return new WaitForSeconds(seconds);
        }

    }


}

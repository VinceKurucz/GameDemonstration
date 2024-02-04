using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activace : MonoBehaviour
{
    public GameObject obj;

    private bool inzone;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            inzone = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = false;
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if(inzone == true  && Input.GetButtonDown("Submit") && obj.activeSelf == false)
        {
            obj.SetActive(true);
        }
        else if (inzone == true && Input.GetButtonDown("Submit") && obj.activeSelf == true)
        {
            obj.SetActive(false);
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle1Switch : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject purple;
    private bool inzone;

    public float current;

    private void Start()
    {
        current = 1f;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = false;
        }
    }
    private void Update()
    {
        if(inzone == true)
        {
            if (Input.GetButtonDown("Submit"))
            {
                current++;
            }
        }

        if (current >= 5f)
        {
            current = 1f;
        }

        if (current == 4f)
        {
            purple.gameObject.SetActive(false);
            blue.gameObject.SetActive(true);

        }
        if (current == 3f)
        {
            yellow.gameObject.SetActive(false);
            purple.gameObject.SetActive(true);

        }
        if (current == 2f)
        {
            red.gameObject.SetActive(false);
            yellow.gameObject.SetActive(true);

        }

        if (current == 1f)
        {
            blue.gameObject.SetActive(false);
            red.gameObject.SetActive(true);

        }

    }

}
    



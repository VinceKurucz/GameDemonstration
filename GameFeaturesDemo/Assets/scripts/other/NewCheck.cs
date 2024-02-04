using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheck : MonoBehaviour
{

    public GameObject Disable;

    void Awake()
    {
        if(FindObjectOfType<PlayerHealthManager>().newgame == true)
        {
            Disable.SetActive(true);
            FindObjectOfType<PlayerHealthManager>().newgame = false;
           
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecticTrap : MonoBehaviour
{

   public GameObject sparkles;

    public float wait = 3f;
    public float wait2 = 3f;


    private void Awake()
    {
        StartCoroutine(Coroutine());
    }



    IEnumerator Coroutine()
    {
        while (true)
        {
            

            sparkles.gameObject.SetActive(false);

            yield return new WaitForSeconds(wait);

            sparkles.gameObject.SetActive(true);

            yield return new WaitForSeconds(wait2);

        }
    }
}

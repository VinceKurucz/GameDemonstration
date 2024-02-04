using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exlosion : MonoBehaviour
{
    public float seconds;

    //ExampleScriptHellYeah
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {


        yield return new WaitForSeconds(seconds);

        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroy : MonoBehaviour
{
    public float seconds;

    // I made two identical scripts... "Explosion"
    void Start()
    {
        StartCoroutine(destory());
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

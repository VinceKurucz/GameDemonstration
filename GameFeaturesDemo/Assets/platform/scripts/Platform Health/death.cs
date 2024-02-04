using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{


    private void FixedUpdate()
    {
        System.Threading.Thread.Sleep(200);

        Destroy(gameObject);
    }

}

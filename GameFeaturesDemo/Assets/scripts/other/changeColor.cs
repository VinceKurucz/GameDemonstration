using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    private Renderer rend;
    private float waitforSeconds;
    private float waitforSeconds2;


    public Color colorToTurn = Color.white;

    void Start()
    {
        rend = GetComponent<Renderer>();       
    }

    // making the colours flashing
     public void Colorchange()
    {
        if (waitforSeconds <= 10f)
        {
            rend.material.color = colorToTurn;
            waitforSeconds++;
        }
        if (waitforSeconds >= 10f)
        {
            rend.material.color = Color.white;
            waitforSeconds++;
        }
      if(waitforSeconds >= 20f)
        {
            waitforSeconds = 0f;
        }                                  
    }

    private void FixedUpdate()
    {
        
        if(rend.material.color == colorToTurn)
        {
            waitforSeconds2++;
            if(waitforSeconds2>50f)
            {
                rend.material.color = Color.white;
            }
        }
    }

}

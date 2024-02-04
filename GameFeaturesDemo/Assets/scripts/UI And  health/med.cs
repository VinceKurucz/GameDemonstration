using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class med : MonoBehaviour
{
    public int current;
    public int numberofmeds;

    public Image[] meds;
    public Sprite fullmeds;
    public Sprite emmptymeds;

    


     void Update()
    {
        current = GetComponent<PlayerHealthManager>().currentNumberOfMeds;
        numberofmeds = GetComponent<PlayerHealthManager>().numberOfMeds;

        for (int i = 0; i < meds.Length; i++)
        {

            if(i >= current)
            {
                meds[i].sprite = emmptymeds;
            }
            else if(i <= current)
            {
                meds[i].sprite = fullmeds;
            }
            if(i < numberofmeds)
            {
                 meds[i].enabled = true;
            }
            else
            {
                meds[i].enabled = false;
            }
        }
        
    }
}

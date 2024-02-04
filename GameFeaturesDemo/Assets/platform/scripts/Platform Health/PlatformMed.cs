using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMed : MonoBehaviour
{
    public int current;
    public int numberofmeds;

    public Image[] meds;
    public Sprite fullmeds;
    public Sprite emmptymeds;

    private void FixedUpdate()
    {
        current = GetComponent<PlatformPlayerHealth>().currentNumberOfMeds;
        numberofmeds = GetComponent<PlatformPlayerHealth>().numberOfMeds;
    }

    void Update()
    {


        for (int i = 0; i < meds.Length; i++)
        {

            if (i >= current)
            {
                meds[i].sprite = emmptymeds;
            }
            else if (i <= current)
            {
                meds[i].sprite = fullmeds;
            }
            if (i < numberofmeds)
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

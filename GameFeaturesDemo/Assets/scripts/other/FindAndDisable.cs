using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAndDisable : MonoBehaviour
{

    private GameObject toDisable;
    private GameObject toEnable;
    public string Disable;
    public string Enable;



    private void Start()
    {
        toDisable = GameObject.Find(Disable);
        toEnable = GameObject.Find(Enable);
    }

    void Ena()
    {
        toDisable.SetActive(true);
        toEnable.SetActive(false);
    }

    void Disa()
    {
        toDisable.SetActive(false);
        toEnable.SetActive(true);
    }
}

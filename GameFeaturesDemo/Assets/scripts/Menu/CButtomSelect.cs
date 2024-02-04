using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CButtomSelect : MonoBehaviour
{
    public Button StartButtom;

    private v2ChoiceManager Manager;
    private bool selected;

    void Start()
    {
        Manager = FindObjectOfType<v2ChoiceManager>();
    }
    void Update()
    {
        if (Manager.choiceActive == true && selected == false)
        {
            StartButtom.Select();
            selected = true;
        }
        else if(Manager.choiceActive == false)
        {
            selected = false;
        }

    }
}

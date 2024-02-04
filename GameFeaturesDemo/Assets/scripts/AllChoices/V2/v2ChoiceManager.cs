using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class v2ChoiceManager : MonoBehaviour
{
    public GameObject cBox;

    public Text cText;
    public Text Buttom1Text;
    public Text Buttom2Text;

    [HideInInspector]
    public bool choiceActive;
    public float choice;

  


    public void choiceActivate()
    {
        cBox.SetActive(true);
        choiceActive = true;
    }

    public void choice1()
    {
        choice = 1f;
        cBox.SetActive(false);
        choiceActive = false;
    }
    public void choice2()
    {
        choice = 2f;
        cBox.SetActive(false);
        choiceActive = false;
    }

}

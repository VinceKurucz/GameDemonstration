using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtomSelect : MonoBehaviour
{
    public Button startButtom;

    // void OnEnable may needed later
    //complicated_script.exe
    void OnEnable()
    {
        startButtom.Select();
    }


}

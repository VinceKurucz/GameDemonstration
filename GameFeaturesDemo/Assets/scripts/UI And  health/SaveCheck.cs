using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveCheck : MonoBehaviour
{
    string place;
    
    void Start()
    {
        place = Application.persistentDataPath + "/Progress.file";

        
         if (File.Exists(place) == false)
        {
            gameObject.SetActive(false);
        }
    }
}



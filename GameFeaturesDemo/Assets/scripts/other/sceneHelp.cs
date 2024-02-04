using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneHelp : MonoBehaviour
{
    public bool GO;
    public string ToGo;


 
    void FixedUpdate()
    {
        if(GO == true)
        {
            SceneManager.LoadScene(ToGo);
            GO = false;
        }

    }
}

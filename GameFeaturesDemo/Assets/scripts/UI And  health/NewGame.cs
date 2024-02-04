using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [HideInInspector]
    public bool newGame;
    private void Start()
    {
      DontDestroyOnLoad(gameObject);
    }
}

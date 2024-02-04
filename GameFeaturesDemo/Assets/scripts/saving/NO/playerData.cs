using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class playerData
{

    public int health;
    public float[] position;

    public playerData (PlayerHealthManager playerHealthManager)
    {
        health = playerHealthManager.playerMaxHealth;      
    
        position = new float[3];
        position[0] = playerHealthManager.transform.position.x;
        position[1] = playerHealthManager.transform.position.y;
        position[2] = playerHealthManager.transform.position.z;

    }

}

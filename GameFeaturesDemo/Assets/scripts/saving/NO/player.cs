using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public PlayerHealthManager health;
    
    
    public void savePlayer()
    {
        saveSystem.savePlayer(health);
    }
    public void loadPlayer()
    {
        playerData data = saveSystem.loadPlayer();

        health.playerCurrentHealth = data.health;
       
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealtManager : MonoBehaviour
{
    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;

    public ParticleSystem effect;
   
    void Start()
    {
        EnemyCurrentHealth = EnemyMaxHealth;
    }

    // magic
    void Update()
    {
        
        if(EnemyCurrentHealth <= 0)
        {
            effect.transform.position = gameObject.transform.position;
            if (effect == true)
            {
                effect.Play();
            }
          Destroy(gameObject);
        }

    }
    public void hurtEnemy(int damageToGive)
    {
        EnemyCurrentHealth -= damageToGive;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    public int damageToGive;   
    GameObject controll;
    //private EnemyHealtManager enemy;

    // Animation in the Controller script


    public  void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name != "Player" && Input.GetKey(KeyCode.F) && other.gameObject.GetComponent<EnemyHealtManager>() == true && ControllerScript.isMoving == false)
        {
            // hurting the enemy
           // enemy = other.gameObject.GetComponent<EnemyHealtManager>();
          //  attack();

            other.gameObject.GetComponent<EnemyHealtManager>().hurtEnemy(damageToGive);

            // slowing down the enemy
            if (other.gameObject.GetComponent<FollowV2>() == true)
            {
                other.gameObject.GetComponent<FollowV2>().speed /= 2;              
            }
            // make the enemy flash
            if(other.gameObject.GetComponent<changeColor>() == true)
            {
                other.gameObject.GetComponent<changeColor>().Colorchange();
            }
        }       
    }

    public  void Update()
    {     
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0.15f, 0f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(-0.15f, 0f);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0f, 0.25f);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(0f, -0.25f);
        }
    }

    public void attack()
    {
       // enemy.hurtEnemy(damageToGive);
    }
    
}

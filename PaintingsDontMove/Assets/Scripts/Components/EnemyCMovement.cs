using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCMovement : EnemyMovement
{
    private bool godMode = false;
    private int enemyHP = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagEnum.Attack)
        {
            if (!godMode && enemyHP > 0)
            {
                enemyHP--;
                godMode = true;
                Knockback(other);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Enemy C is Dead");
                generator.SlowEnemyIsDead();
            }
        }

        if (other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            Debug.Log("teste\n");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Knockback(Collider2D other)
    {
        
        godMode = false;
    }
}

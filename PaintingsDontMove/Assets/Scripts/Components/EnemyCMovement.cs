﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCMovement : EnemyMovement
{

    private int enemyHP = 1;
    public float knockbackTargetTimer = 1.5f;
    private bool godMode = false;
    

    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            Vector2 pos = transform.position;
            pos.x -= (speed * Time.deltaTime) * directionModifier;
            transform.position = pos;

            if (godMode) {
                knockbackTargetTimer -= Time.deltaTime;

                if (knockbackTargetTimer <= 0)
                {
                    StopKnockback();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagEnum.Attack)
        {
            //Destroy(gameObject);
            //generator.SlowEnemyIsDead();
            if (enemyHP > 0 && !godMode)
             {
                godMode = true;
                enemyHP--;
                StartKnockback();
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

    private void StartKnockback()
    {
        base.directionModifier = -2f;
    }

    private void StopKnockback()
    {
        godMode = false;
        base.directionModifier = 1;
    }
}

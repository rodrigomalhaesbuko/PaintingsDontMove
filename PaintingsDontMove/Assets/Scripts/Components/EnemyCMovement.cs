using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCMovement : EnemyMovement
{

    private int enemyHP = 1;
    public float knockbackTargetTimer = 1.5f;
    private bool godMode = false;
    private GameManager gm;

    private void Start()
    {
        points = 40;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            GetComponent<Animator>().SetTrigger("Move");
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
        }else
        {
            GetComponent<Animator>().SetTrigger("Idle");
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
                StartCoroutine(ApplyScore());
                Destroy(gameObject);
                Debug.Log("Enemy C is Dead");
                generator.SlowEnemyIsDead();
            }
        }

        if (other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            Debug.Log("teste\n");
            gm.GameOverDied();
        }


        if (other.gameObject.tag == TagEnum.Hit)
        {
            StartCoroutine(PlayParticle(other.gameObject));
            GameObject.Find("Montu").GetComponent<Animator>().SetTrigger("Attack");
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

    IEnumerator ApplyScore()
    {
        gm.score += points;
        Instantiate(deathParticle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        yield return null;

    }

    IEnumerator PlayParticle(GameObject other)
    {
        other.GetComponent<ParticleComponent>().PlayParticle();
        yield return null;
    }
}

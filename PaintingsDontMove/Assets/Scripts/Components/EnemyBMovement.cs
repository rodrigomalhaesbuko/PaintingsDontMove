using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBMovement : EnemyMovement
{
    private GameManager gm;
    private void Start()
    {
        points = 20;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == TagEnum.Attack)
        {
            StartCoroutine(ApplyScore());
            Destroy(gameObject);
            Debug.Log("Enemy B is Dead");
            generator.SlowEnemyIsDead();
        }

        if (other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            Debug.Log("teste\n");
            gm.GameOverDied();
        }

        if (other.gameObject.tag == TagEnum.Hit)
        {
            GameObject.Find("Montu").GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    IEnumerator ApplyScore()
    {
        gm.score += points;
        yield return null;

    }
}

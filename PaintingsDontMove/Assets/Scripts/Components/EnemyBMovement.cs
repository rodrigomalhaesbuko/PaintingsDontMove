using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBMovement : EnemyMovement
{
    private GameManager gm;
    private void Start()
    {
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
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator ApplyScore()
    {
        gm.score += poits;
        yield return null;

    }
}

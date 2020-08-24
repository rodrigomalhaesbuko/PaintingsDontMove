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
            StartCoroutine(PlayParticle(other.gameObject));
            GameObject.Find("Montu").GetComponent<Animator>().SetTrigger("Attack");
        }
    }

    IEnumerator ApplyScore()
    {
        gm.score += points;
        Debug.Log("OBBAAAAAAAAA");
        Instantiate(deathParticle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(EraseParticle());
        yield return null;

    }

    IEnumerator EraseParticle()
    {
        yield return new WaitForSeconds(3);
        Destroy(deathParticle);
    }

    IEnumerator PlayParticle(GameObject other)
    {

        other.GetComponent<ParticleComponent>().PlayParticle();
        yield return null;
    }
}

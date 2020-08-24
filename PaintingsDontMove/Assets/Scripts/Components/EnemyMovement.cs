using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject deathParticle;
    public int points = 15;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public EnemyGenerator generator;
    public float directionModifier = 1f;

    // Update is called once per frame
    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            GetComponent<Animator>().SetTrigger("Move");
            Vector2 pos = transform.position;
            pos.x -= (speed * Time.deltaTime) * directionModifier ;
            transform.position = pos;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Idle");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == TagEnum.Attack)
        {
            StartCoroutine(ApplyScore());
            Destroy(gameObject);
        }

        if(other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            gm.GameOverDied();
        }

        if (other.gameObject.tag == TagEnum.Hit)
        {
            StartCoroutine(PlayParticle(other.gameObject));
            GameObject.Find("Montu").GetComponent<Animator>().SetTrigger("Attack");
            //Instantiate(deathParticle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    IEnumerator ApplyScore()
    {
        gm.score += points;
        yield return new WaitForSeconds(1);
      
    }

    IEnumerator PlayParticle(GameObject other)
    {

        other.GetComponent<ParticleComponent>().PlayParticle();
        yield return null;
    }
}

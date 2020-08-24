using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
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
            gm.GameOver();
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

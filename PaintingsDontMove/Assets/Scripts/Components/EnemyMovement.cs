using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            Vector2 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == TagEnum.Attack)
        {
            StartCoroutine(applyScore());
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

    IEnumerator applyScore()
    {
        gm.score += 15;
        yield return null;
           
    }
}

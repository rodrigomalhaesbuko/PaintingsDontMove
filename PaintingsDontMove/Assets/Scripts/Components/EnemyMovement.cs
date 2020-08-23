using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public EnemyGenerator generator;
    public float directionModifier = 1f;

    // Update is called once per frame
    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            Vector2 pos = transform.position;
            pos.x -= (speed * Time.deltaTime) * directionModifier ;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == TagEnum.Attack)
        {
            PlayerController.score++;
            Destroy(gameObject);
        }

        if(other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            Debug.Log("teste\n");
            SceneManager.LoadScene("GameOver");
        }

        if (other.gameObject.tag == TagEnum.Hit)
        {
            GameObject.Find("Montu").GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}

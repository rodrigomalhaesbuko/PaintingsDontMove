using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public EnemyGenerator generator;
    private int enemyHP = 2;
    private int directionModifier = 1;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x -= (speed * Time.deltaTime)*directionModifier;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == TagEnum.Attack)
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == TagEnum.Hieroglyph)
        {
            //end game
            Debug.Log("teste\n");
            SceneManager.LoadScene("GameOver");
        }
    }
}

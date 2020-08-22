using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OBAA");
        if(other.gameObject.tag == TagEnum.Attack)
        {
            Destroy(gameObject);
        }
    }
}

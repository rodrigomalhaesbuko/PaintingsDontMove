using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject EnemyA;
    public float spawnTimeInit;
    public float spawnTimeEnd;
    private float spawnTime;
    private float counter = 0;

    private void Start()
    {
        spawnTime = Random.Range(spawnTimeInit, spawnTimeEnd);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > spawnTime)
        {
            counter = 0;
            spawnTime = Random.Range(spawnTimeInit, spawnTimeEnd);
            StartCoroutine(SpawEnemy());
        }

    }

    IEnumerator SpawEnemy()
    {
        Instantiate(EnemyA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject EnemyA;
    public GameObject EnemyB;
    public GameObject EnemyC;
    public float spawnTimeInit;
    public float spawnTimeEnd;
    private float spawnTime;
    private float counter = 0;
    private int randomEnemy;
    private bool slowEnemySpawned = false;    

    private void Start()
    {
        spawnTime = Random.Range(spawnTimeInit, spawnTimeEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeManipulation.ZAWARUDO)
        {
            counter += Time.deltaTime;
            if (counter > spawnTime)
            {
                counter = 0;
                spawnTime = Random.Range(spawnTimeInit, spawnTimeEnd);
                StartCoroutine(SpawEnemy());
            }
        }
    }

    IEnumerator SpawEnemy()
    {
        randomEnemy = Random.Range(0, 100);
        Debug.Log("Slow Enemy Slow is: " + slowEnemySpawned);
        if (!slowEnemySpawned)
        {
            if (randomEnemy >= 0 && randomEnemy <= 50)
            {
                GameObject enemy = Instantiate(EnemyA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
            }

            if (randomEnemy > 50 && randomEnemy <= 75)
            {
                slowEnemySpawned = true;
                GameObject enemy = Instantiate(EnemyB, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
            }

            if (randomEnemy > 75 && randomEnemy <= 100)
            {
                slowEnemySpawned = true;
                GameObject enemy = Instantiate(EnemyC, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
            }
        }
        
        yield return null;
    }

    public void SlowEnemyIsDead()
    {
        slowEnemySpawned = false;
    }
}

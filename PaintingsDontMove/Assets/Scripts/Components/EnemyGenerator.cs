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
    public float firstSpawn;
    private float spawnTime;
    private float counter = 0;
    private int randomEnemy;
    private bool slowEnemySpawned = false;
    private int chanceToSpawnA = 0;
    private int chanceToSpawnB = 0;
    private int chanceToSpawnC = 0;

    private void Start()
    {
        spawnTime = firstSpawn;
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
        if (AdmireComponent.howManyTimesWasAdmired >= 0 && AdmireComponent.howManyTimesWasAdmired < 2)
        {
            chanceToSpawnA = 100;
            chanceToSpawnB = 0;
            chanceToSpawnC = 0;
        }

        if (AdmireComponent.howManyTimesWasAdmired >= 2 && AdmireComponent.howManyTimesWasAdmired < 4)
        {
            chanceToSpawnA = 65;
            spawnTimeInit = 3;
            spawnTimeEnd = 8;
            chanceToSpawnB = 25;
            chanceToSpawnC = 10;
        }

        if (AdmireComponent.howManyTimesWasAdmired >= 4 && AdmireComponent.howManyTimesWasAdmired < 6)
        {
            spawnTimeInit = 2;
            spawnTimeEnd = 7;
            chanceToSpawnA = 50;
            chanceToSpawnB = 25;
            chanceToSpawnC = 25;
        }

        randomEnemy = Random.Range(0, 100);
        Debug.Log("Slow Enemy Slow is: " + slowEnemySpawned);
        if (!slowEnemySpawned)
        {
            if (randomEnemy >= 0 && randomEnemy <= chanceToSpawnA)
            {
                GameObject enemy = Instantiate(EnemyA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
            }

            if (chanceToSpawnB != 0)
            {
                if (randomEnemy > chanceToSpawnA && randomEnemy <= chanceToSpawnA + chanceToSpawnB)
                {
                    slowEnemySpawned = true;
                    GameObject enemy = Instantiate(EnemyB, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
                }
            }

            if (chanceToSpawnC != 0)
            {
                if (chanceToSpawnA + chanceToSpawnB <= randomEnemy && chanceToSpawnA + chanceToSpawnB + chanceToSpawnC <= 100)
                {
                    slowEnemySpawned = true;
                    GameObject enemy = Instantiate(EnemyC, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    enemy.GetComponent<EnemyMovement>().generator = gameObject.GetComponent<EnemyGenerator>();
                }
            }
        }
        
        yield return null;
    }

    public void SlowEnemyIsDead()
    {
        slowEnemySpawned = false;
    }
}

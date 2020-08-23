using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowsController : MonoBehaviour
{
    public GameObject ShadowA;
    private float spawnTime;
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > spawnTime)
        {
            counter = 0;
            StartCoroutine(SpawEnemy());
        }

    }

    IEnumerator SpawEnemy()
    {
        Instantiate(ShadowA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        yield return null;
    }
}

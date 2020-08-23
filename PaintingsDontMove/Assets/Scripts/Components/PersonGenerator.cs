using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGenerator : MonoBehaviour
{
    public GameObject PersonA;
    public GameObject ShadowA;

    private float spawnTime = 5;
    private float counter = 0;
    public bool walking = false;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > spawnTime)
        {
            counter = 0;
            if (!walking)
            {
                CreateShadow();
            }
            
        }

    }


    public void CreatePerson()
    {
        walking = true;
        Instantiate(PersonA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateShadow()
    {
        Instantiate(ShadowA, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}

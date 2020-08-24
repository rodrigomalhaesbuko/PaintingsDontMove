using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    public GameObject particle;
    public GameObject particle2;
    public bool right = false;

    public void PlayParticle()
    {
        Debug.Log("TO AQUI NO PARTICLE");
        GameObject particleObject = Instantiate(particle);
        GameObject particleObject2 = Instantiate(particle2);
        Vector3 pos = transform.position;
        Vector3 pos2 = transform.position;
        pos2.y += 2.0f;
        pos.y -= 2.0f;
        if (right)
        {
            pos.x -= 2.5f;
            pos2.x -= 4.5f;

        } else
        {
            
            pos.x += 2.5f;
            pos2.x += 4.5f;
        }

        particleObject.transform.position = pos;
        particleObject2.transform.position = pos2;
        StartCoroutine(DeleteParticle(particleObject));
        StartCoroutine(DeleteParticle(particleObject2));
    }


    IEnumerator DeleteParticle(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

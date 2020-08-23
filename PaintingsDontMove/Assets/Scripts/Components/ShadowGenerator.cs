using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGenerator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagEnum.ShadowBarrier))
        {
            //trigger 3DPeaple
            Destroy(other.gameObject);
            GameObject.Find("3DPersonGenerator").GetComponent<PersonGenerator>().CreatePerson();
        }

        if (other.gameObject.CompareTag(TagEnum.Person))
        {
            GameObject.Find("3DPersonGenerator").GetComponent<PersonGenerator>().walking = false;
            Destroy(other.gameObject);
        }


    }



}

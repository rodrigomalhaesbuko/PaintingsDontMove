using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagEnum.ShadowBarrier))
        {
            //trigger 3DPeaple
            GameObject.Find("3DPersonGenerator").GetComponent<PersonGenerator>().CreatePerson();
        }
    }
}

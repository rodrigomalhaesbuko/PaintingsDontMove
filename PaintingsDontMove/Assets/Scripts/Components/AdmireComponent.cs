using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmireComponent : MonoBehaviour
{
    public static bool isAdmiring = false;
    public static int howManyTimesWasAdmired = 0;
    private void Start()
    {
        isAdmiring = false;
        howManyTimesWasAdmired = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagEnum.Person))
        {
            //trigger 3DPeaple
            other.GetComponent<Animator>().SetTrigger("Admire");
            other.GetComponent<ShadowMovement>().speed = 0;
            isAdmiring = true;
            StartCoroutine(StopAdmiring(other.gameObject));

        }
    }

    IEnumerator StopAdmiring(GameObject other)
    {
        yield return new WaitForSeconds(1.5f);
        other.GetComponent<Animator>().SetTrigger("DontAdmire");
        other.GetComponent<ShadowMovement>().speed = 8;
        isAdmiring = false;
        howManyTimesWasAdmired++;
    }

}

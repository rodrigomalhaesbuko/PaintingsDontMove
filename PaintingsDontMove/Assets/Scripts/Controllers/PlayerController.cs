using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dist;
    private GameObject attackLeft;
    private GameObject attackRight;
    private void Start()
    {
        attackLeft = transform.GetChild(1).gameObject;
        attackRight = transform.GetChild(0).gameObject;

    }
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Vector2 pos = transform.position;
            pos.y += dist;
            transform.position = pos; 
        }

        if (Input.GetKeyDown("down"))
        {
            Vector2 pos = transform.position;
            pos.y -= dist;
            transform.position = pos;
        }

        if (Input.GetKeyDown("left"))
        {
            transform.eulerAngles = Vector3.zero;
            GetComponent<SpriteRenderer>().color = Color.red;
            attackLeft.SetActive(true);
        }else 
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            attackLeft.SetActive(false);
        }

        if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            GetComponent<SpriteRenderer>().color = Color.red;
            attackRight.SetActive(true);
        }else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            attackRight.SetActive(false);
        }
    }


}

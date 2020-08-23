using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dist;
    private GameObject attackLeft;
    private GameObject attackRight;

    private Rigidbody rb;
    private bool isDead = false;

    private int xPosition = 0;
    private int yPosition = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        attackLeft = transform.GetChild(1).gameObject;
        attackRight = transform.GetChild(0).gameObject;

    }
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            if (yPosition != 2)
            {
                transform.position = transform.position + new Vector3(0, 6, 0);
                yPosition += 1;

            }
        }

        if (Input.GetKeyDown("down"))
        {
            if (yPosition != 0)
            {
                transform.position = transform.position + new Vector3(0, -6, 0);
                yPosition -= 1;

            }
        }

        if (Input.GetKeyDown("left"))
        {
            transform.eulerAngles = Vector3.zero;
            attackLeft.SetActive(true);
            attackRight.SetActive(false);

            if (xPosition != 0)
            {
                transform.position = transform.position + new Vector3(-6, 0, 0);
                xPosition -= 1;

            }

        }

        if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            attackRight.SetActive(true);
            attackLeft.SetActive(false);

            if (xPosition != 1)
            {
                transform.position = transform.position + new Vector3(6, 0, 0);
                xPosition += 1;

            }
        }
    }


}

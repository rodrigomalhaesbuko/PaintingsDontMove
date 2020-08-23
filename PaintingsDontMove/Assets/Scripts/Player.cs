using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDead = false;

    private int xPosition = 1;
    private int yPosition = 0;

 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!isDead)
        {

            if (Input.GetKeyDown("up"))
            {   
                if (yPosition != 2)
                {
                    transform.position = transform.position + new Vector3(0, 3, 0);
                    yPosition += 1;

                }
            }

            else if (Input.GetKeyDown("down"))
            {
                if (yPosition != 0)
                {
                    transform.position = transform.position + new Vector3(0, -3, 0);
                    yPosition -= 1;

                }
            }

            else if (Input.GetKeyDown("right"))
            {
                if (xPosition != 1)
                {
                    transform.position = transform.position + new Vector3(5, 0, 0);
                    xPosition += 1;

                }
            }

            else if (Input.GetKeyDown("left"))
            {
                if ( xPosition != 0)
                {
                    transform.position = transform.position + new Vector3(-5, 0, 0);
                    xPosition -= 1;

                }
            }

        }
    }
}

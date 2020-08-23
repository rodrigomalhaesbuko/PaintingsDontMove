using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float dist;
    private GameObject attackLeft;
    private GameObject attackRight;

    private Rigidbody rb;
    private bool isDead = false;

    private int xPosition = 0;
    private int yPosition = 1;

    private const int maxPauwa = 3;

    private float standoPauwa = 3;

    private const float verticalStep = 5;

    public Image pauwaImg;

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
                transform.position = transform.position + new Vector3(0, verticalStep, 0);
                yPosition += 1;

            }
        }

        if (Input.GetKeyDown("down"))
        {
            if (yPosition != 0)
            {
                transform.position = transform.position + new Vector3(0, - verticalStep, 0);
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

        if (Input.GetKey("space"))
        {
            if (standoPauwa > 0)
            {
                timeManipulation.ZAWARUDO = true;
                standoPauwa -= Time.deltaTime;

            }
            else
            {
                timeManipulation.ZAWARUDO = false;
            }
        }
        else
        {
            timeManipulation.ZAWARUDO = false;

            if (standoPauwa < maxPauwa)
                standoPauwa += Time.deltaTime/2;
        }

        pauwaImg.fillAmount = standoPauwa/maxPauwa;
        //Debug.Log(standoPauwa);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dist;
    private void FixedUpdate()
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
        }

        if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    public float speed;
    private float yStart;
    public float ySpeed;

    private void Start()
    {
        yStart = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        pos.y = yStart + (1.1f * ySpeed * Mathf.Sin(Time.time * 1));
        transform.position = pos;
    }
}

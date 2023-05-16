using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowJumping : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float zPos;

    public float amp;
    public float freq;

    void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xPos, Mathf.Sin(Time.time * freq) * amp + yPos, zPos);
    }
}

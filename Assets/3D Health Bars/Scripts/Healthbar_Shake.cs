using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar_Shake : MonoBehaviour
{
    public float speed = 1.0f;
    public float amount = 1.0f;

    public bool trigger;
    bool shake;
    public float timer;

    void Update()
    {
        if (trigger)
        {
            StartCoroutine(StartShake());
            trigger = false;
        }
        if (shake)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x - (Mathf.Sin(speed * timer) * amount), transform.position.y, transform.position.z);
        }
    }

    IEnumerator StartShake()
    {
        timer = .5f;
        shake = true;
        yield return new WaitForSeconds(.35f);
        transform.position = transform.parent.position;
        shake = false;
        timer = 0f;
    }
}

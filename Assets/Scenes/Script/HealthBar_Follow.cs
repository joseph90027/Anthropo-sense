using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar_Follow : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 BarOffset;

    public float smoothfactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        BarOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        void LateUpdate()
        {
            Vector3 newPosition = targetObject.transform.position + BarOffset;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothfactor);

        }
    }

}

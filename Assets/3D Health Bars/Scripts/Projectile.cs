using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 4f;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HB_Unit_Health>().AddPoint(damage);
        Destroy(gameObject);
    }
}

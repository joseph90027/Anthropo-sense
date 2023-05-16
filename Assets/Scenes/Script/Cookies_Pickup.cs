using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookies_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            print("item picked up");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

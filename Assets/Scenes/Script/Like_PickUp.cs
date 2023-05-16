using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like_PickUp : MonoBehaviour
{
    


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Like picked up");
            Destroy(gameObject);
        }


    }

    
}

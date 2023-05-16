using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeSetActive : MonoBehaviour
{
    public GameObject Obj;
    // Start is called before the first frame update
    public void custtomizeSetActive()
    {
        /*
        if(Obj.activeSelf == true)
        {
            Obj.SetActive(false);
            Debug.Log("turnOff");
        }
        else
        {
            Obj.SetActive(true);
            Debug.Log("turnOn");
        }
        */

        Obj.SetActive(true);
    }
}

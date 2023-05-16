using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting_Cookies : MonoBehaviour
{
    public int cookies;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "cookies";
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "cookies")
        {
            Debug.Log("Cookie Collected");
            cookies = cookies + 1;
            Col.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieNumber : MonoBehaviour
{
    public Text Count;
    public float cookieNum;


    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "cookies")
        {
            cookieNum ++;
            print("cookieNum + " + cookieNum);
        }

        if (collider.gameObject.tag == "Portal")
        {
            cookieNum = Mathf.Round((cookieNum / 2));
            print("cookieNum + " + cookieNum);
        }

        if (collider.gameObject.tag == "Timer")
        {

        }
    }


    

    private void Start()
    {
        cookieNum = 0f;
    }
    void Update()
    {
        Count.text = cookieNum.ToString();
    }
}

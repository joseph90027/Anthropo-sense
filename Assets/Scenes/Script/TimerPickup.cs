using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPickup : MonoBehaviour
{
    private float startTime;
    private string minutes;
    private string seconds;
    private bool runonlyOnce;

    //Vector3 move = Vector3.zaxis;

    private IEnumerator WaitBeforeShow()
    {

        yield return new WaitForSeconds(2);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("item picked up");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f0");


        int i = (int)t / 60;


        if (i % 2 == 1 && seconds == "0" && i != 0)
        {

            StartCoroutine(WaitBeforeShow());
            transform.Translate((Vector3.forward*100f) * Time.deltaTime);
        }
        //transform.Translate((Vector3.forward) * Time.deltaTime);
    }
}

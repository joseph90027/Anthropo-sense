using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAndShow : MonoBehaviour
{

    public GameObject SecondVideo;
    public GameObject FirstVideo;

    public bool canDeactivate = false;
    private float timer = 0f;
    private const float DELAY_TIME = 8f;


    private void Update()
    {
        if (canDeactivate == true)
        {
            Debug.Log("canDeactivate = " + canDeactivate);

            // Start the delay timer
            timer += Time.deltaTime;
            
            // Check if the timer has reached the delay time
            if (timer >= DELAY_TIME)
            {
                Debug.Log("timer is set!!!!!!");
                
                // Set the game object's active flag to false
                SecondVideo.SetActive(true);
                canDeactivate = false;
            }
        }

    }

    public void SetActiveShow()
    {

        FirstVideo.SetActive(false);
        Debug.Log("hide");

        canDeactivate = true;

    }
}

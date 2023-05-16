using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SecondVideo;
    public GameObject FirstVideo;
    private Image myImage;

    public bool canDeactivate = false;
    private float timer = 0f;
    private const float DELAY_TIME = 9f;
    private int pressNum = 0;

    void Start()
    {
        // Get the Image component attached to this GameObject
        myImage = GetComponent<Image>();
    }

    void Update()
    {
        
        if (canDeactivate == true && pressNum <= 0)
        {
            // Start the delay timer
            timer += Time.deltaTime;

            // Check if the timer has reached the delay time
            if (timer >= DELAY_TIME)
            {
                Debug.Log("timer is set!!!!!!");

                // Set the game object's active flag to false
                SecondVideo.SetActive(true);
                pressNum++;
                canDeactivate = false;
                //FirstVideo.SetActive(false);
            }
        }

    }

    public void SetActiveShow()
    {
        if(pressNum <= 0)
        {
            myImage.enabled = false;
            Debug.Log("hide");
            //SecondVideo.SetActive(true);
            canDeactivate = true;
        }
        else
        {
            FirstVideo.SetActive(false);
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;

public class getCurrentGazeTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LogCurrentGazeTarget();
    }

    void LogCurrentGazeTarget()
    {
        if (CoreServices.InputSystem.GazeProvider.GazeTarget)
        {
            /*
            Debug.Log("User gaze is currently over game object: "
                + CoreServices.InputSystem.GazeProvider.GazeTarget);
            */
            //if(GameObject.ReferenceEquals(CoreServices.InputSystem.GazeProvider.GazeTarget, GameObject ))

            /*
            if (CoreServices.InputSystem.GazeProvider.GazeTarget.ToString() == "chair02 (1)")
            {
                //Debug.Log(CoreServices.InputSystem.GazeProvider.GazeTarget.ToString());
                Debug.Log("YESSSSSSS");
            }
            */
            
            //Debug.Log("User gaze direction is " + CoreServices.InputSystem.GazeProvider.GazeDirection);
        }
    }
}

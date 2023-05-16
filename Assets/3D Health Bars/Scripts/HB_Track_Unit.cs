using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB_Track_Unit : MonoBehaviour
{
    public GameObject pairedUnit;
    public Transform trackedLocation;
    public GameObject lifeBar;
    public ParticleSystem barFX;
    public GameObject healthbarHolder;

    Vector3 myVector;

    // Start is called before the first frame update
    void Start()
    {
        myVector = new Vector3(0.0f, 27.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (trackedLocation != null)
        {
            
            //Keeps position locked to whoever spawned it with the healthbar me script
            transform.position = trackedLocation.transform.position + myVector;
            return;
        }
        //transform.LookAt(Camera.main.transform);
    }
}

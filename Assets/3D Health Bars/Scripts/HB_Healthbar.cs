using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB_Healthbar : MonoBehaviour
{
    public GameObject thisHealthbar;

    public Color32 barColor;
    public ParticleSystem breakFX;

    [Range(0.0f, 3.0f)]
    public float healthbarHeightScale = 1;

    //Use this to make a little slider for variables
    [Range(0.0f, 3.0f)]
    public float healthbarWidthScale = 1;

    public bool shakeOnHit = true;

    ParticleSystem.MainModule main;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate a gameobject from Resources folder and save it as a variable - VERY USEFUL
        GameObject go = Instantiate((GameObject)Resources.Load("Healthbar Prefab"));
        go.GetComponent<HB_Track_Unit>().pairedUnit = gameObject;
        thisHealthbar = go;
        GetComponent<HB_Unit_Health>().healthBarHolder = go.GetComponent<HB_Track_Unit>().healthbarHolder;
        breakFX = go.GetComponent<HB_Track_Unit>().barFX;

        //I just slapped a script to a child of the healthbar to use GetComponentInChildren
        if (GetComponentInChildren<Healthbar_Search>() != null)
        {
            go.GetComponent<HB_Track_Unit>().trackedLocation = GetComponentInChildren<Healthbar_Search>().transform;
        }
    }

    void Update()
    {
        //First frame Healthbar isn't stored, so this just waits to make sure its set
        if (thisHealthbar != null)
        {
            //Adjust Color at runtime - You should probably move this to start if not needed
            thisHealthbar.GetComponent<HB_Track_Unit>().lifeBar.GetComponent<MeshRenderer>().material.color = barColor;
            breakFX.transform.GetChild(0).GetComponent<Renderer>().material.color = barColor;


            // Scale size of the Particle FX and child with Height/width
            thisHealthbar.transform.localScale = new Vector3(healthbarWidthScale, healthbarHeightScale, healthbarHeightScale);
            breakFX.transform.localScale = new Vector3(1, healthbarHeightScale, healthbarHeightScale);
            breakFX.transform.GetChild(0).localScale = new Vector3(healthbarHeightScale, healthbarHeightScale, healthbarHeightScale);
        }
    }


}

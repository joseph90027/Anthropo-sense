using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoSthWhenManipulationStartedOrEnded : MonoBehaviour
{
    public float transformX;
    public float transformY;
    public float transformZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    
    private float desiredDuration = 0.5f;
    private float elapsedTime;

    private Vector3 end_pos;
    private Vector3 start_pos;
    private Vector3 end_rotation;
    private Vector3 start_rotation;

    private bool triggerReleased = false;

    public Material ChangedMaterial;
    private Material OriginalMaterial;

    public Renderer renderTitle;
    public Renderer renderSubtitle;

    public GameObject BouncingSphere;
    public Slider mainSlider;
    public Slider subSlider;



    private void Start()
    {
        //OriginalMaterial = GetComponent<Renderer>().material;
        //GetComponent<Renderer>().material = ChangedMaterial;
    }


    private void Update()
    {    
        
        if(triggerReleased == true) {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.localPosition = Vector3.Lerp(start_pos, end_pos, percentageComplete);
            transform.eulerAngles = new Vector3(Mathf.Lerp(transform.localRotation.x, rotationX, percentageComplete), Mathf.Lerp(transform.localRotation.y, rotationY, percentageComplete), Mathf.Lerp(transform.localRotation.z, rotationZ, percentageComplete));

            if (percentageComplete >= 1)
            {
                //GetComponent<Renderer>().material = OriginalMaterial;


                if(BouncingSphere != null)
                {
                    BouncingSphere.SetActive(false);
                }

                triggerReleased = false;

            }
        }

    }


    public void MoveObjectToDestination()
    {
        
        
        end_pos = new Vector3(transformX, transformY, transformZ);
        start_pos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

 
        end_rotation = new Vector3(rotationX, rotationY, rotationZ);
        start_rotation = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);

        //transform.localPosition = end_pos;
        //transform.eulerAngles = end_rotation;

        triggerReleased = true;
        mainSlider.value = mainSlider.value + 4;
        subSlider.value = subSlider.value + 12;

    }

    public void HighlightingObjectDestination()
    {
        end_pos = new Vector3(transformX, transformY, transformZ);

    }

    public void StartBouncingSphere()
    {
        BouncingSphere.SetActive(true);

        if (renderTitle != null && renderSubtitle != null)
        {
            renderTitle.enabled = false;
            renderSubtitle.enabled = false;
        }
    }


}

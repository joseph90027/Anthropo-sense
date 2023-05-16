using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAppear_Destroy : MonoBehaviour
{
    [SerializeField] private Image customImage;
    public float delay;
    private Renderer rend;
    private GameObject cat;
    private MeshRenderer[] MR;



    void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = false;
        MR = GetComponentsInChildren<MeshRenderer>();
        
    }

    private IEnumerator WaitBeforeShow(Image customImage, float delay)
    {
        
        customImage.enabled = true;
        //cat.GetComponent<Renderer>().enabled = false;
        foreach (MeshRenderer joint in MR)
            joint.enabled = false;

        yield return new WaitForSeconds(delay);
        
        customImage.enabled = false;
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player")) 
        {
       
            StartCoroutine(WaitBeforeShow(customImage, delay));
            print("Like picked up");
        }
        

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAppear_Remain : MonoBehaviour
{
    [SerializeField] private Image customImage;
    public float delay;
    private Renderer rend;
    private GameObject cat;
    private MeshRenderer[] MR;



    private IEnumerator WaitBeforeShow(Image customImage, float delay)
    {
        
        customImage.enabled = true;

        yield return new WaitForSeconds(delay);
        
        customImage.enabled = false;

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

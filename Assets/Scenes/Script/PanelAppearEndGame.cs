using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelAppearEndGame : MonoBehaviour
{
    [SerializeField] private Image customImage;
    public float delay;
    private Renderer rend;
    private GameObject cat;
    private MeshRenderer[] MR;



    private IEnumerator WaitBeforeShow(Image customImage, float delay)
    {

        customImage.enabled = true;
        
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
        yield return new WaitForSeconds(6f);
        customImage.enabled = false;
        //SceneManager.LoadScene(0);
        //Application.LoadLevel("VoxelWorld_Demo01");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {

            StartCoroutine(WaitBeforeShow(customImage, delay));
            print("Like picked up");
            //SceneManager.LoadScene("VoxelWorld_Demo01");
            //Application.LoadLevel("VoxelWorld_Demo01");
            //SceneManager.LoadScene(0);
        }
    }


    
}

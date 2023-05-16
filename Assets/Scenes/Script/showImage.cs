using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImage : MonoBehaviour
{
    private UnityEngine.UI.Image image;

    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();

        //HideImage();
        ShowImage();
    }

    // Start is called before the first frame update
    public void ShowImage()
    {
        image.enabled = true;

        // ===== OR =====

        gameObject.SetActive(true);

    }
    public void HideImage()
    {
        image.enabled = false;

        // ===== OR =====

        gameObject.SetActive(false);
    }
}
